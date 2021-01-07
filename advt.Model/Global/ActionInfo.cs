namespace advt.Model.Global
{

    public class ActionInfo
    {
        public ActionInfo()
        {
        }

        public ActionInfo(string _name)
        {
            m_name = _name;
        }

        private object m_roleValues;

        public object RoleValues
        {
            get { return m_roleValues; }
            set { m_roleValues = value; }
        }

        private object m_htmlAttribute;

        public object HtmlAttribute
        {
            get { return m_htmlAttribute; }
            set { m_htmlAttribute = value; }
        }

        public ActionInfo(string _name, string _action, string _controller, object _RoleValues, object _HtmlAttribute)
        {
            m_name = _name;
            m_action = _action;
            m_controller = _controller;
            m_roleValues = _RoleValues;
            m_htmlAttribute = _HtmlAttribute;
        }

        public ActionInfo(string _name, string _action, string _controller, object _RoleValues)
        {
            m_name = _name;
            m_action = _action;
            m_controller = _controller;
            m_roleValues = _RoleValues;
        }

        public ActionInfo(string _name, string _action, string _controller)
        {
            m_name = _name;
            m_action = _action;
            m_controller = _controller;
        }

        private string m_name;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private string m_action;

        public string Action
        {
            get { return m_action; }
            set { m_action = value; }
        }
        private string m_controller;

        public string Controller
        {
            get { return m_controller; }
            set { m_controller = value; }
        }
    }
}
