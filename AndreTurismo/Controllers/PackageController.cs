using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class PackageController
    {
        public bool InsertPackage(Package package)
        {
            
            return new PackageService().InsertPackage(package);
        }

        public bool DeletePackage(Package package)
        {
            return new PackageService().DeletePackage(package);
        }

        public List<Package> GetPackageList()
        {
            return new PackageService().GetPackageList();
        }

        public bool UpdatePackage(Package package)
        {
            return new PackageService().UpdatePackage(package);
        }
    }
}
