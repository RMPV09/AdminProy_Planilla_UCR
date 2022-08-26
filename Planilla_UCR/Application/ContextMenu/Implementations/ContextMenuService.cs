using System;

namespace Application.ContextMenu.Implementations
{
    public class ContextMenuService : IContextMenuService
    {
        private event Action? OnChange;
        private bool _showProjectsMenu { get; set; } = false;
        private string _projectContext { get; set; }
        private string _employerEmailContext { get; set; }
        private bool _showProjectsSubMenu { get; set; } = false;
        private bool _hoursEmployee { get; set; } = false;
        private bool _showReports { get; set; } = false;

        public string GetProjectsContext()
        {
            return _projectContext;
        }

        public void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }  

        public void SetProjectsContext(bool showProjectsMenu, bool showProjectsSubMenu, string projectName, string employerEmail, bool hoursEmployee, bool showReports)
        {
            _showProjectsMenu = showProjectsMenu;
            _showProjectsSubMenu = showProjectsSubMenu;
            _projectContext = projectName;
            _employerEmailContext = employerEmail;
            _hoursEmployee = hoursEmployee;
            _showReports = showReports;
            NotifyStateChanged();
        }

        public bool GetShowProjectsMenu()
        {
            return _showProjectsMenu;
        }

        public void SetOnChange(Action action)
        {
            OnChange += action;
        }

        public bool GetShowProjectsSubMenu()
        {
            return _showProjectsSubMenu;
        }

        public string GetEmployerEmailContext()
        {
            return _employerEmailContext;
        }

        public bool GetHoursEmployeeContext()
        {
            return _hoursEmployee;
        }

        public bool GetReportsContext()
        {
            return _showReports;
        }
    }
}
