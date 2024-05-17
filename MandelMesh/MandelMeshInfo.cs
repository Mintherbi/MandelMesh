using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace MandelMesh
{
    public class MandelMeshInfo : GH_AssemblyInfo
    {
        public override string Name => "MandelMesh";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("6de466a4-a2f1-43db-a5e0-c865a09403dd");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}