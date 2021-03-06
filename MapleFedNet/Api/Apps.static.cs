﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapleFedNet.Common;
using MapleFedNet.Model;

namespace MapleFedNet.Api
{
    public class Apps
    {
        /// <summary>
        ///     Registering an application
        /// </summary>
        /// <param name="domain">mastodon instance domain</param>
        /// <param name="client_name">Name of your application</param>
        /// <param name="website">(optional) URL to the homepage of your app</param>
        /// <param name="redirect_uris">
        ///     Where the user should be redirected after authorization (for no redirect, use
        ///     <see cref="Constants.NoRedirect" />)
        /// </param>
        /// <param name="scopes">
        ///     This can be a space-separated list of the following items: <see cref="SCOPE_READ" />,
        ///     <see cref="SCOPE_WRITE" /> and <see cref="SCOPE_FOLLOW" />
        /// </param>
        /// <returns>
        ///     <see cref="AppRegistration" />
        /// </returns>
        public static async Task<AppRegistration> Register(string domain, string client_name, string website = "",
            string redirect_uris = Constants.NoRedirect, IEnumerable<Scope> scopes = null)
        {
			if (scopes == null)
				scopes = Enumerable.Empty<Scope>();
            return await HttpHelper.Instance.PostAsync<AppRegistration, string>($"{HttpHelper.HTTPS}{domain}{Constants.AppsRegistering}",
                null, (nameof(client_name), client_name), (nameof(redirect_uris), redirect_uris),
                (nameof(website), website), (nameof(scopes), string.Join(" ", scopes.Select(it => it.ToString("F").ToLowerInvariant()))));
        }
    }
}