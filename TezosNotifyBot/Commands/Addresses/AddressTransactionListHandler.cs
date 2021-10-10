using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TezosNotifyBot.Abstractions;
using TezosNotifyBot.Domain;
using TezosNotifyBot.Model;
using TezosNotifyBot.Shared.Extensions;
using TezosNotifyBot.Shared.Models;
using TezosNotifyBot.Storage;
using TezosNotifyBot.Storage.Extensions;
using TezosNotifyBot.Tzkt;

namespace TezosNotifyBot.Commands.Addresses
{
    public class AddressTransactionListHandler : BaseHandler, ICallbackHandler
    {
        private AddressTransactionsRepository TransactionsRepository { get; }
        private const int takePerPage = 10;

        private readonly ITzKtClient tzKtClient;
        private readonly ResourceManager lang;

        public AddressTransactionListHandler(
            TezosDataContext db,
            TezosBotFacade botClient,
            ResourceManager lang,
            AddressTransactionsRepository transactionsRepository
        )
            : base(db, botClient)
        {
            TransactionsRepository = transactionsRepository;
            this.lang = lang;
        }

        public async Task Handle(string[] args, CallbackQuery query)
        {
            var page = args.GetInt(1);
            var userId = query.From.Id;
            var address = args[0];

            var userAddress = await Db.Set<UserAddress>()
                .SingleOrDefaultAsync(x => x.Address == address && x.UserId == userId);

            if (userAddress == null)
                throw new ArgumentException($"Address {args[0]} not found");

            var user = await Db.Users.ByIdAsync(userAddress.UserId);

            var pager = TransactionsRepository.GetPage(userAddress.Address, page, takePerPage);

            var message = new MessageBuilder()
                .AddLine(
                    lang.Get(
                        Res.AddressTransactionListTitle,
                        user.Language,
                        new { addressName = userAddress.DisplayName() }
                    )
                )
                .AddEmptyLine()
                .WithHashTag("transaction_list")
                .WithHashTag(userAddress);

            foreach (var tx in pager.Items)
            {
                var row = lang.Get(Res.AddressTransactionListItem, user.Language, new
                {
                    hash = tx.Hash,
                    icon = BuildIcon(tx),
                    amount = tx.Amount,
                    targetName = tx.Target.DisplayName(),
                    targetAddress = tx.Target.address,
                    timestamp = tx.Timestamp.ToLocaleString(user.Language),
                    t = Explorer.FromId(user.Explorer),
                });
                message.AddLine(row);
            }

            await Bot.EditText(
                query.From.Id,
                query.Message.MessageId,
                message.Build(!userAddress.User.HideHashTags),
                parseMode: ParseMode.Html,
                disableWebPagePreview: true,
                replyMarkup: BuildKeyboard()
            );

            string BuildIcon(Transaction transaction)
            {
                if (transaction.Sender.address == address)
                    return "➖";
                if (transaction.Target.address == address)
                    return "➕";
                return "?";
            }
            
            InlineKeyboardMarkup BuildKeyboard()
            {
                var callback = $"address-transaction-list {userAddress.Address}";
                if (pager.Page == 1 && !pager.HasNext)
                    return new InlineKeyboardMarkup(
                        InlineKeyboardButton.WithCallbackData(
                            lang.Get(Res.AddressTransactionListRefresh, user.Language), $"{callback} 1")
                    );

                var older = InlineKeyboardButton.WithCallbackData(
                    lang.Get(Res.AddressTransactionListOlder, user.Language), $"{callback} {pager.Page + 1}");
                var newer = InlineKeyboardButton.WithCallbackData(
                    lang.Get(Res.AddressTransactionListNewer, user.Language), $"{callback} {pager.Page - 1}");
                var latest =
                    InlineKeyboardButton.WithCallbackData(lang.Get(Res.AddressTransactionListLatest, user.Language),
                        $"{callback} 1");

                if (pager.Page == 1)
                    return new InlineKeyboardMarkup(older);
                if (pager.HasPrev && !pager.HasNext)
                    return new InlineKeyboardMarkup(new[] { newer, latest, });

                return new InlineKeyboardMarkup(new[] { newer, latest, older, });
            }
        }

        public async Task HandleException(Exception exception, object sender, CallbackQuery query)
        {
            await Bot.NotifyAdmins(exception.Message);
        }
    }

    public class AddressTransactionsRepository
    {
        private ITzKtClient TzKtClient { get; }

        public AddressTransactionsRepository(ITzKtClient tzKtClient)
        {
            TzKtClient = tzKtClient;
        }

        public Paginated<Transaction> GetPage(string address, int page, int take)
        {
            var offset = (page - 1) * take;
            var filter = new QueryBuilder
            {
                { "anyof.sender.target", address },
                { "limit", "11" },
                { "offset", $"{offset}" },
                { "sort.desc", "id" },
                { "status", "applied"}
            };

            var result = TzKtClient.GetTransactions<Transaction>(filter.ToQueryString()).ToArray();

            return result.ToFlexPagination(page, take);
        }
    }
}