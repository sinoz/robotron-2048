using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

namespace Robotron_2048
{
    /// <summary>
    /// Describes the different types of behaviours of a scene on a stage.
    /// </summary>
    abstract class Scene : Drawable, Updatable {
        /// <summary>
        /// TODO
        /// </summary>
        public abstract void Hide();
        
        /// <summary>
        /// TODO
        /// </summary>
        public abstract void Show();

        /// <summary>
        /// Disposes off all of the resources this scene is entitled to.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// TODO
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// TODO
        /// </summary>
        public abstract void Update();
    }

    /// <summary>
    /// Describes a main menu scene.
    /// </summary>
    sealed class MainMenu : Scene
    {
        public override void Hide()
        {
            // TODO
        }

        public override void Show()
        {
            // TODO
        }

        public override void Dispose()
        {
            // TODO
        }

        public override void Draw()
        {
            // TODO
        }

        public override void Update()
        {
            // TODO
        }
    }
}
