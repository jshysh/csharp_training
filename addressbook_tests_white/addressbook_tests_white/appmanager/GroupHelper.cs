using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WPFUIItems;
using TestStack.White.WindowsAPI;

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase

    {
        public static string GROUPWINTITLE = "Group editor";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialog = OpenGroupsDialog();
            Tree tree = dialog.Get<Tree>("uxAddressTreeView");

            TreeNode root = tree.Nodes[0];

            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });

            }
            CloseGroupsDialog(dialog);
            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialog = OpenGroupsDialog();
            dialog.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN); //simulate ENTER

            CloseGroupsDialog(dialog);
        }

         public void CloseGroupsDialog(Window dialog)
        {
            dialog.Get<Button>("uxCloseAddressButton").Click();

        }

        private Window OpenGroupsDialog()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        public void Delete(int index)
        {
            Window dialog = OpenGroupsDialog(); //opening group dialog

            Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            root.Nodes[index].Select();

            dialog.Get<Button>("uxDeleteAddressButton").Click();
            dialog.Get<RadioButton>("uxDeleteGroupsOnlyRadioButton").Click(); //move contacts before delete
//          dialog.Get<RadioButton>("uxDeleteAllRadioButton").Click(); //delete all
            dialog.Get<Button>("uxOKAddressButton").Click();
            
            CloseGroupsDialog(dialog);
        }

       
        public void VerifyGroupExists()
        {
            if (GetGroupList().Count < 0)
            {
                GroupData group = new GroupData();
                Add(group);
            }
        }
    }
}