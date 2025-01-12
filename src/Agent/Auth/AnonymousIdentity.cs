using EdjCase.ICP.Candid.Crypto;
using EdjCase.ICP.Candid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdjCase.ICP.Agent.Auth
{
	public class AnonymousIdentity : IIdentity
	{

		public Task<SignedContent> CreateSignedContent(Dictionary<string, IHashable> request)
		{
			return Task.FromResult(new SignedContent(request, null, null, null));
		}

		public Principal GetPrincipal() => Principal.Anonymous();
	}
}
