using System;
using System.Globalization;
using System.IO;
using System.Linq;
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


        [Parameter(Position = 1, ParameterSetName = "DefaultParameterSet", Mandatory = false)]
        public string[] Cultures
        {
            get { return _cultures; }
            set { _cultures = value; }
        }

        #endregion


        #region Overrides

        protected override void BeginProcessing()
        {
            if (!File.Exists(_path))
            {
                ThrowTerminatingError(new ErrorRecord(new FileNotFoundException("Input RESX file not found.", _path),
                    "FileNotFound", ErrorCategory.InvalidArgument, _path));
            }

            if (_cultures == null || _cultures.Length == 0)
            {
                // init defaults
                _cultures = new[] {"ar-AE", "cs-CZ", "el-GR", "es-CL", "kk-KZ", "ky-KG", "ru-RU", "uk-UA"};
            }

            _cultures = _cultures
                .Select(c =>
                {
                    try
                    {
                        return CultureInfo.CreateSpecificCulture(c).Name;
                    }
                    catch (Exception)
                    {
                        WriteWarning(string.Format("Cannot bind culture for param '{0}'", c));
                        return null;
                    }
                })
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .ToArray();
        }

        protected override void ProcessRecord()
        {
            var fileName = System.IO.Path.GetFileNameWithoutExtension(_path);

            foreach (var culture in _cultures)
            {
                var newPath = fileName + "." + culture + ".resx";
                WriteVerbose(string.Format("Processing file '{0}' to '{1}' ", _path, newPath));
                File.Copy(_path, newPath);
            }
        }

        #endregion

    }
}
