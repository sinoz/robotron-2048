using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotron_2048.Source.Scene
{
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
