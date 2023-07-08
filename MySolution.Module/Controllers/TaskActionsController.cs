using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using MySolution.Module.BusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySolution.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class TaskActionsController : ViewController
    {
        private ChoiceActionItem setPriorityItem;
        private ChoiceActionItem setStatusItem;

        public TaskActionsController()
        {
            InitializeComponent();
            TargetObjectType = typeof(DemoTask);


            SingleChoiceAction SetTaskAction = new SingleChoiceAction(this, "SetTaskAction", PredefinedCategory.Edit)
            {
                Caption = "Set Task",
                //Specify the display mode for the Action's items. Here the items are operations that you perform against selected records.
                ItemType = SingleChoiceActionItemType.ItemIsOperation,
                //Set the Action to become available in the Task List View when a user selects one or more objects.
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects
            };

            setPriorityItem = new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(DemoTask), "Priority"), null);
            SetTaskAction.Items.Add(setPriorityItem);
            FillItemWithEnumValues(setPriorityItem, typeof(Priority));

            setStatusItem = new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(DemoTask), "Status"), null);
            SetTaskAction.Items.Add(setStatusItem);
            FillItemWithEnumValues(setStatusItem, typeof(DevExpress.Persistent.Base.General.TaskStatus));

            SetTaskAction.Execute += SetTaskAction_Execute;
        }

        private void SetTaskAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            /*Create a new ObjectSpace if the Action is used in List View
              Use this ObjectSpace to manipulate the View's selected objects.*/
            IObjectSpace objectSpace = View is ListView ?
                Application.CreateObjectSpace(typeof(DemoTask)) : View.ObjectSpace;
            ArrayList objectsToProcess = new ArrayList(e.SelectedObjects);
            if (e.SelectedChoiceActionItem.ParentItem == setPriorityItem)
            {
                foreach (Object obj in objectsToProcess)
                {
                    DemoTask objInNewObjectSpace = (DemoTask)objectSpace.GetObject(obj);
                    objInNewObjectSpace.Priority = (Priority)e.SelectedChoiceActionItem.Data;
                }
            }
            else
                if (e.SelectedChoiceActionItem.ParentItem == setStatusItem)
            {
                foreach (Object obj in objectsToProcess)
                {
                    DemoTask objInNewObjectSpace = (DemoTask)objectSpace.GetObject(obj);
                    objInNewObjectSpace.Status = (DevExpress.Persistent.Base.General.TaskStatus)e.SelectedChoiceActionItem.Data;
                }
            }
            objectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
        }
        private void FillItemWithEnumValues(ChoiceActionItem parentItem, Type enumType)
        {
            EnumDescriptor ed = new EnumDescriptor(enumType);
            foreach (object current in ed.Values)
            {
                ChoiceActionItem item = new ChoiceActionItem(ed.GetCaption(current), current);
                item.ImageName = ImageLoader.Instance.GetEnumValueImageName(current);
                parentItem.Items.Add(item);
            }
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
