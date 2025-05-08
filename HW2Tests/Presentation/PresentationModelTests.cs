using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW2.Command;
using HW2.Mock;

namespace HW2.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        PresentationModel pModel;
        Model model;
        [TestInitialize]
        public void SetUp()
        {
            model = new Model();
            pModel = new PresentationModel(model);
        }
        [TestMethod()]
        public void StartTest()
        {
            pModel.Start();
            Assert.IsTrue(pModel.IsStartEnabled());
            Assert.IsFalse(pModel.IsProcessEnabled());
            Assert.IsFalse(pModel.IsTerminatorEnabled());
            Assert.IsFalse(pModel.IsDecisionEnabled());
            Assert.IsFalse(pModel.IsPointerEnabled());
        }

        [TestMethod()]
        public void TerminationTest()
        {
            pModel.Termination();
            Assert.IsFalse(pModel.IsStartEnabled());
            Assert.IsFalse(pModel.IsProcessEnabled());
            Assert.IsTrue(pModel.IsTerminatorEnabled());
            Assert.IsFalse(pModel.IsDecisionEnabled());
            Assert.IsFalse(pModel.IsPointerEnabled());
        }

        [TestMethod()]
        public void ProcessTest()
        {
            pModel.Process();
            Assert.IsFalse(pModel.IsStartEnabled());
            Assert.IsTrue(pModel.IsProcessEnabled());
            Assert.IsFalse(pModel.IsTerminatorEnabled());
            Assert.IsFalse(pModel.IsDecisionEnabled());
            Assert.IsFalse(pModel.IsPointerEnabled());
        }

        [TestMethod()]
        public void DecisionTest()
        {
            pModel.Decision();
            Assert.IsFalse(pModel.IsStartEnabled());
            Assert.IsFalse(pModel.IsProcessEnabled());
            Assert.IsFalse(pModel.IsTerminatorEnabled());
            Assert.IsTrue(pModel.IsDecisionEnabled());
            Assert.IsFalse(pModel.IsPointerEnabled());
        }

        [TestMethod()]
        public void PointerStateTest()
        {
            pModel.PointerState();
            Assert.IsFalse(pModel.IsStartEnabled());
            Assert.IsFalse(pModel.IsProcessEnabled());
            Assert.IsFalse(pModel.IsTerminatorEnabled());
            Assert.IsFalse(pModel.IsDecisionEnabled());
            Assert.IsTrue(pModel.IsPointerEnabled());

        }

        [TestMethod()]
        public void GetEnabledStatusTest()
        {
            pModel.Process();
            Assert.AreEqual(pModel.GetEnabledStatus(), "Process");
            pModel.PointerState();
            Assert.AreEqual(pModel.GetEnabledStatus(), "None");
            pModel.Start();
            Assert.AreEqual(pModel.GetEnabledStatus(), "Start");
            pModel.Decision();
            Assert.AreEqual(pModel.GetEnabledStatus(), "Decision");
            pModel.Termination();
            Assert.AreEqual(pModel.GetEnabledStatus(), "Terminator");
        }

        [TestMethod()]
        public void DescribtionInput_TextChangedTest()
        {
            pModel.DescribtionInput_TextChanged("");
            Assert.IsFalse(pModel.isDescribtionChanged);
            Assert.AreEqual(pModel.DescribtionColor, System.Drawing.Color.Red);
            pModel.DescribtionInput_TextChanged("123");
            Assert.IsTrue(pModel.isDescribtionChanged);
            Assert.AreEqual(pModel.DescribtionColor, System.Drawing.Color.Black);
            pModel.DescribtionInput_TextChanged("asfagasg");
            Assert.IsTrue(pModel.isDescribtionChanged);
            Assert.AreEqual(pModel.DescribtionColor, System.Drawing.Color.Black);
            pModel.DescribtionInput_TextChanged("");
            Assert.IsFalse(pModel.isDescribtionChanged);
            Assert.AreEqual(pModel.DescribtionColor, System.Drawing.Color.Red);
        }

        [TestMethod()]
        public void XInput_TextChangedTest()
        {
            pModel.XInput_TextChanged("123");
            Assert.IsTrue(pModel.isXInputTextChanged);
            Assert.AreEqual(pModel.XInputTextColor, System.Drawing.Color.Black);
            pModel.XInput_TextChanged("osaiolfnjashif");
            Assert.IsFalse(pModel.isXInputTextChanged);
            Assert.AreEqual(pModel.XInputTextColor, System.Drawing.Color.Red);
            pModel.XInput_TextChanged("-100");
            Assert.IsFalse(pModel.isXInputTextChanged);
            Assert.AreEqual(pModel.XInputTextColor, System.Drawing.Color.Red);
            pModel.XInput_TextChanged("0");
            Assert.IsFalse(pModel.isXInputTextChanged);
            Assert.AreEqual(pModel.XInputTextColor, System.Drawing.Color.Red);
        }

        [TestMethod()]
        public void YInput_TextChangedTest()
        {
            pModel.YInput_TextChanged("98765");
            Assert.IsTrue(pModel.isYInputTextChanged);
            Assert.AreEqual(pModel.YInputTextColor, System.Drawing.Color.Black);
            pModel.YInput_TextChanged("sahasdnds");
            Assert.IsFalse(pModel.isYInputTextChanged);
            Assert.AreEqual(pModel.YInputTextColor, System.Drawing.Color.Red);
            pModel.YInput_TextChanged("-999999");
            Assert.IsFalse(pModel.isYInputTextChanged);
            Assert.AreEqual(pModel.YInputTextColor, System.Drawing.Color.Red);
            pModel.YInput_TextChanged("0");
            Assert.IsFalse(pModel.isYInputTextChanged);
            Assert.AreEqual(pModel.YInputTextColor, System.Drawing.Color.Red);
        }

        [TestMethod()]
        public void HInput_TextChangedTest()
        {
            pModel.HInput_TextChanged("-8406264");
            Assert.IsFalse(pModel.isHInputTextChanged);
            Assert.AreEqual(pModel.HInputTextColor, System.Drawing.Color.Red);
            pModel.HInput_TextChanged("ashfukashf");
            Assert.IsFalse(pModel.isHInputTextChanged);
            Assert.AreEqual(pModel.HInputTextColor, System.Drawing.Color.Red);
            pModel.HInput_TextChanged("0");
            Assert.IsFalse(pModel.isHInputTextChanged);
            Assert.AreEqual(pModel.HInputTextColor, System.Drawing.Color.Red);
            pModel.HInput_TextChanged("523132");
            Assert.IsTrue(pModel.isHInputTextChanged);
            Assert.AreEqual(pModel.HInputTextColor, System.Drawing.Color.Black);

        }

        [TestMethod()]
        public void WInput_TextChangedTest()
        {
            pModel.WInput_TextChanged("123");
            Assert.IsTrue(pModel.isWInputTextChanged);
            Assert.AreEqual(pModel.WInputTextColor, System.Drawing.Color.Black);
            pModel.WInput_TextChanged("asfsagasgg");
            Assert.IsFalse(pModel.isWInputTextChanged);
            Assert.AreEqual(pModel.WInputTextColor, System.Drawing.Color.Red);
            pModel.WInput_TextChanged("-100");
            Assert.IsFalse(pModel.isWInputTextChanged);
            Assert.AreEqual(pModel.WInputTextColor, System.Drawing.Color.Red);
            pModel.WInput_TextChanged("0");
            Assert.IsFalse(pModel.isWInputTextChanged);
            Assert.AreEqual(pModel.WInputTextColor, System.Drawing.Color.Red);
        }

        [TestMethod()]
        public void ShapeDecide_SelectedIndexChangedTest()
        {
            pModel.ShapeDecide_SelectedIndexChanged("Process");
            Assert.IsTrue(pModel.isShapeChanged);
            Assert.AreEqual(pModel.ShapeChangedColor, System.Drawing.Color.Black);
            pModel.ShapeDecide_SelectedIndexChanged("Start");
            Assert.IsTrue(pModel.isShapeChanged);
            Assert.AreEqual(pModel.ShapeChangedColor, System.Drawing.Color.Black);
            pModel.ShapeDecide_SelectedIndexChanged("形狀");
            Assert.IsFalse(pModel.isShapeChanged);
            Assert.AreEqual(pModel.ShapeChangedColor, System.Drawing.Color.Red);
            pModel.ShapeDecide_SelectedIndexChanged("Terminator");
            Assert.AreEqual(pModel.ShapeChangedColor, System.Drawing.Color.Black);
            Assert.IsTrue(pModel.isShapeChanged);
            pModel.ShapeDecide_SelectedIndexChanged("Decision");
            Assert.IsTrue(pModel.isShapeChanged);
            Assert.AreEqual(pModel.ShapeChangedColor, System.Drawing.Color.Black);
        }

        [TestMethod()]
        public void CheckInputEnabledTest()
        {
            pModel.XInput_TextChanged("123");
            pModel.YInput_TextChanged("98765");
            pModel.HInput_TextChanged("523132");
            pModel.WInput_TextChanged("123");
            pModel.CheckInputEnabled();
            Assert.IsFalse(pModel.IsAddButtonEnabled);
            pModel.ShapeDecide_SelectedIndexChanged("Process");
            pModel.DescribtionInput_TextChanged("asfagasg");
            pModel.CheckInputEnabled();
            Assert.IsTrue(pModel.IsAddButtonEnabled);
            //Assert.
        }

        [TestMethod()]
        public void NotifyTest()
        {
            string expectedPropertyName = "TestProperty";
            bool eventRaised = false;

            // Subscribe to the PropertyChanged event
            pModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == expectedPropertyName)
                {
                    eventRaised = true;
                }
            };

            // Act
            pModel.Notify(expectedPropertyName);

            // Assert
            Assert.IsTrue(eventRaised, $"PropertyChanged event was not raised for {expectedPropertyName}");
        }

        [TestMethod()]
        public void UpdateUndoRedoTest()
        {
            CommandManager commandManager = new CommandManager();
            MockCommand mockCommand = new MockCommand();
            commandManager.Execute(mockCommand);
            Assert.IsTrue(commandManager.IsUndoEnabled);
            commandManager.Undo();
            Assert.IsTrue(commandManager.IsRedoEnabled);
            Assert.IsFalse(commandManager.IsUndoEnabled); 
            model.commandManager.Execute(mockCommand);
            pModel.UpdateUndoRedo();
            Assert.IsTrue(pModel.IsUndoEnabled);
            Assert.IsFalse(pModel.IsRedoEnabled);
        }

    }
}