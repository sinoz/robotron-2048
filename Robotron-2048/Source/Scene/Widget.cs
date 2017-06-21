using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotron_2048.Source.Scene
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
}
