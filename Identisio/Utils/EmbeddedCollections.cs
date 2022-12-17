using Microsoft.Extensions.FileProviders;
using Skyware.Identisio.Model.Resources.Bg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Skyware.Identisio.Utils
{
    public class EmbeddedCollections
    {
        #region Props
        
        public static EmbeddedCollections Instance { get; } = new EmbeddedCollections();
        public HealthInstitutions EmbeddedInstitutions { get; set; }
        public HealthRegions EmbeddedRegions { get; set; }

        #endregion

        #region Fields

        private EmbeddedFileProvider _embeddedProvider = new EmbeddedFileProvider(Assembly.GetExecutingAssembly());

        #endregion

        private EmbeddedCollections()
        {
            using (var institutionsRead = _embeddedProvider.GetFileInfo("Resources\\Bg\\practice-types.xml").CreateReadStream())
            using (var regionsRead = _embeddedProvider.GetFileInfo("Resources\\Bg\\regions.xml").CreateReadStream())
            {
                EmbeddedInstitutions = XmlUtils.GetObject<HealthInstitutions>(institutionsRead);
                EmbeddedRegions = XmlUtils.GetObject<HealthRegions>(regionsRead);
            }
        }
    }
}
