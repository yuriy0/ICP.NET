using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using EdjCase.ICP.Candid.Mapping;
using EdjCase.ICP.Candid;

namespace Sample.Shared.Governance.Models
{
	public class ListNeurons
	{
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("neuron_ids")]
		public System.Collections.Generic.List<ulong> NeuronIds { get; set; }
		
		[EdjCase.ICP.Candid.Mapping.CandidNameAttribute("include_neurons_readable_by_caller")]
		public bool IncludeNeuronsReadableByCaller { get; set; }
		
	}
}

