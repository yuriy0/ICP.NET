using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid;

namespace Sample.Shared.Governance.Models
{
	public class ProposalData
	{
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("id")]
		public EdjCase.ICP.Candid.Models.OptionalValue<NeuronId> Id { get; set; }
		
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("failure_reason")]
		public EdjCase.ICP.Candid.Models.OptionalValue<GovernanceError> FailureReason { get; set; }
		
		public class R2V0
		{
			[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("0")]
			public ulong F0 { get; set; }
			
			[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("1")]
			public Ballot F1 { get; set; }
			
		}
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("ballots")]
		public System.Collections.Generic.List<R2V0> Ballots { get; set; }
		
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("proposal_timestamp_seconds")]
		public ulong ProposalTimestampSeconds { get; set; }
		
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("reward_event_round")]
		public ulong RewardEventRound { get; set; }
		
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("failed_timestamp_seconds")]
		public ulong FailedTimestampSeconds { get; set; }
		
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("reject_cost_e8s")]
		public ulong RejectCostE8s { get; set; }
		
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("latest_tally")]
		public EdjCase.ICP.Candid.Models.OptionalValue<Tally> LatestTally { get; set; }
		
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("decided_timestamp_seconds")]
		public ulong DecidedTimestampSeconds { get; set; }
		
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("proposal")]
		public EdjCase.ICP.Candid.Models.OptionalValue<Proposal> Proposal { get; set; }
		
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("proposer")]
		public EdjCase.ICP.Candid.Models.OptionalValue<NeuronId> Proposer { get; set; }
		
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("wait_for_quiet_state")]
		public EdjCase.ICP.Candid.Models.OptionalValue<WaitForQuietState> WaitForQuietState { get; set; }
		
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("executed_timestamp_seconds")]
		public ulong ExecutedTimestampSeconds { get; set; }
		
	}
}

