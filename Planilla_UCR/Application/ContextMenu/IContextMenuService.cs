using System;

namespace Application.ContextMenu
{
    public interface IContextMenuService
    {
        bool GetShowProjectsMenu();
        string GetProjectsContext();
        void SetProjectsContext(bool showProjectMenu,bool showProjectSubMenu, string projectName, string employerEmail, bool hoursEmployee, bool showReports);
        void SetOnChange(Action action);
        void NotifyStateChanged();
        bool GetShowProjectsSubMenu();
        string GetEmployerEmailContext();
        bool GetHoursEmployeeContext();
        bool GetReportsContext();
    }
}
