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
    /// TODO
    /// </summary>
    sealed class Button : Widget
    {
        // TODO
    }

    /// <summary>
    /// TODO
    /// </summary>
    sealed class Label : Widget
    {
        // TODO
    }
}
