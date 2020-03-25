using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Liuww.Ssf.Options
{
    public class SsfOptionsFactory<TOptions> : IOptionsFactory<TOptions> where TOptions : class, new()
    {
        private readonly IEnumerable<IConfigureOptions<TOptions>> _setups;
        private readonly IEnumerable<IPostConfigureOptions<TOptions>> _postConfigures;

        public SsfOptionsFactory(IEnumerable<IConfigureOptions<TOptions>> setups, IEnumerable<IPostConfigureOptions<TOptions>> postConfigures)
        {
            _setups = setups;
            _postConfigures = postConfigures;
        }
        public virtual TOptions Create(string name)
        {
            var options = new TOptions();
            foreach (var setup in _setups)
            {
                if (setup is IConfigureNamedOptions<TOptions> namedSetup)
                {
                    namedSetup.Configure(name,options);
                }
                else if (name == Microsoft.Extensions.Options.Options.DefaultName)
                {
                    setup.Configure(options);
                }
                foreach (var post in _postConfigures)
                {
                    post.PostConfigure(name, options);
                }
            }

            return options;
        }
    }
}