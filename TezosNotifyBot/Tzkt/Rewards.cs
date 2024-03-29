﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TezosNotifyBot.Tzkt
{
	public class Rewards
	{
        public int cycle { get; set; }
        public long balance { get; set; }
        public Baker baker { get; set; }
        public long stakingBalance { get; set; }
        public double expectedBlocks { get; set; }
        public double expectedEndorsements { get; set; }
        public int futureBlocks { get; set; }
        public long futureBlockRewards { get; set; }
        //public int ownBlocks { get; set; }
        //public long ownBlockRewards { get; set; }
        //public int extraBlocks { get; set; }
        public int blocks { get; set; }
        //public long extraBlockRewards { get; set; }
        //public int missedOwnBlocks { get; set; }
        public long blockRewards { get; set; }
        //public long missedOwnBlockRewards { get; set; }
        //public int missedExtraBlocks { get; set; }
        //public long missedExtraBlockRewards { get; set; }
        //public int uncoveredOwnBlocks { get; set; }
        //public long uncoveredOwnBlockRewards { get; set; }
        //public int uncoveredExtraBlocks { get; set; }
        public int missedBlocks { get; set; }
        //public long uncoveredExtraBlockRewards { get; set; }
        public long missedBlockRewards { get; set; }
        public int futureEndorsements { get; set; }
        public long futureEndorsementRewards { get; set; }
        public int endorsements { get; set; }
        public long endorsementRewards { get; set; }
        public int missedEndorsements { get; set; }
        public long missedEndorsementRewards { get; set; }
        //public int uncoveredEndorsements { get; set; }
        //public long uncoveredEndorsementRewards { get; set; }
        //public long ownBlockFees { get; set; }
        //public long extraBlockFees { get; set; }
        public long blockFees { get; set; }
        public long missedBlockFees { get; set; }
        //public long missedOwnBlockFees { get; set; }
        //public long missedExtraBlockFees { get; set; }
        //public long uncoveredOwnBlockFees { get; set; }
        //public long uncoveredExtraBlockFees { get; set; }
        public long doubleBakingRewards { get; set; }
        //public long doubleBakingLostDeposits { get; set; }
        //public long doubleBakingLostRewards { get; set; }
        //public long doubleBakingLostFees { get; set; }
        public long doubleBakingLosses { get; set; }
        public long doubleEndorsingRewards { get; set; }
        //public long doubleEndorsingLostDeposits { get; set; }
        //public long doubleEndorsingLostRewards { get; set; }
        //public long doubleEndorsingLostFees { get; set; }
        public long doubleEndorsingLosses { get; set; }
        public long revelationRewards { get; set; }
        //public long revelationLostRewards { get; set; }
        //public long revelationLostFees { get; set; }
        public long revelationLosses { get; set; }
        public decimal TotalRewards => balance / 1000000M / stakingBalance * TotalBakerRewards;
        public long TotalBakerRewards => blockRewards + endorsementRewards + blockFees + doubleBakingRewards - doubleBakingLosses + doubleEndorsingRewards - doubleEndorsingLosses + revelationRewards - revelationLosses + doublePreendorsingRewards - doublePreendorsingLosses;
        public long TotalBakerRewardsPlan => blockRewards + endorsementRewards + revelationRewards;
        public long TotalBakerLoss => missedBlockRewards + missedEndorsementRewards + missedBlockFees + revelationLosses;

        public ulong delegatedBalance { get; set; }
        public int numDelegators { get; set; }
        //public long futureBlockDeposits { get; set; }        
        //public long blockDeposits { get; set; }        
        //public long futureEndorsementDeposits { get; set; }
        //public long endorsementDeposits { get; set; }
        public long activeStake { get; set; }
        public long selectedStake { get; set; }
        public long doublePreendorsingRewards { get; set; }
        public long doublePreendorsingLosses { get; set; }
    }
}
