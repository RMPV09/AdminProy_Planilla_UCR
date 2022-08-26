namespace Presentation.Projects.Models
{
    internal class SnackHandler
    {
        public bool _saving { get; set; }
        public bool _validInfo { get; set; }
        public bool _created { get; set; }

        public SnackHandler()
        {
            _saving = false;
            _validInfo = false;
            _created = false;
        }
    }
}