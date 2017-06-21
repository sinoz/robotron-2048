using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotron_2048
{
    /// <summary>
    /// TODO
    /// </summary>
    abstract class Widget
    {
        /// <summary>
        /// TODO
        /// </summary>
        private Stage stage;

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="stage"></param>
        public void SetStage(Stage stage)
        {
            this.stage = stage;
        }
    }
    
    /// <summary>
    /// A Widget that is presented as a button for the user to click on.
    /// </summary>
    sealed class Button : Widget
    {
        // TODO
    }

    /// <summary>
    /// A Widget that presents some text.
    /// </summary>
    sealed class Label : Widget
    {
        // TODO
    }

    /// <summary>
    /// A type of Button that takes a label to present inside of it.
    /// </summary>
    sealed class TextButton : Widget
    {
        /// <summary>
        /// The button.
        /// </summary>
        private Button button;

        /// <summary>
        /// The presented label inside of this button.
        /// </summary>
        private Label label;

        /// <summary>
        /// Creates a TextButton. 
        /// </summary>
        public TextButton()
        {
            this.button = new Button();
            this.label = new Label();
        }
    }
}
