using System.Management.Automation;

namespace GrafGenerator.ResxPopulate
{
    [Cmdlet(VerbsCommon.Copy, "Resx", DefaultParameterSetName = "DefaultParameterSet")]
    public class CopyResxCommand: PSCmdlet
    {
        private string _path;
        private string[] _cultures;

        #region Parameters

        [Parameter(Position = 0, ParameterSetName = "DefaultParameterSet", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }


        [Parameter(Position = 1, ParameterSetName = "DefaultParameterSet", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string[] Cultures
        {
            get { return _cultures; }
            set { _cultures = value; }
        }

        #endregion


        #region Overrides

        protected override void BeginProcessing()
        {
            
        }

        protected override void ProcessRecord()
        {
            WriteVerbose("Processing file: " + Path);
        }

        #endregion

    }
}
