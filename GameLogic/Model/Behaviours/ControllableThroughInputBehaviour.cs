using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using GameLogic.Model;
using GameLogic.Util;

namespace GameLogic.Model.Behaviours
{
    /// <summary>
    /// A behavioural act where control over a type of entity is described through the user's input.
    /// </summary>
    public sealed class ControllableThroughInputBehaviour : IEntityBehaviour
    {
        public void Act(Mine mine, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Act(Character character, GameTime gameTime)
        {
            var x = character.position.X;
            var y = character.position.Y;

            if (AppConfig.deviceType == DeviceType.Android)
            {
                TouchCollection touchCollection = TouchPanel.GetState();

                if (touchCollection.Count > 0)
                {
                    #region Borrowed code from MonoGame Documentation - Interpolating towards a user's touch input
                    Vector2 desiredVelocity = new Vector2();

                    desiredVelocity.X = touchCollection[0].Position.X - character.position.X;
                    desiredVelocity.Y = touchCollection[0].Position.Y - character.position.Y;

                    if (desiredVelocity.X != 0 || desiredVelocity.Y != 0)
                    {
                        desiredVelocity.Normalize();
                        const float desiredSpeed = 200;
                        desiredVelocity *= desiredSpeed;
                    }

                    x += desiredVelocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    y += desiredVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

                    bool movingHorizontally = Math.Abs(desiredVelocity.X) > Math.Abs(desiredVelocity.Y);
                    if (movingHorizontally)
                    {
                        if (desiredVelocity.X > 0)
                        {
                            character.currentTexture = LoadedContent.characterRightTex;
                        }
                        else
                        {
                            character.currentTexture = LoadedContent.characterLeftTex;
                        }
                    }
                    else
                    {
                        if (desiredVelocity.Y > 0)
                        {
                            character.currentTexture = LoadedContent.characterDownTex;
                        }
                        else
                        {
                            character.currentTexture = LoadedContent.characterUpTex;
                        }
                    }
                    #endregion
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    y -= (int)(character.velocity * gameTime.ElapsedGameTime.TotalSeconds);
                    character.currentTexture = LoadedContent.characterUpTex;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    y += (int)(character.velocity * gameTime.ElapsedGameTime.TotalSeconds);
                    character.currentTexture = LoadedContent.characterDownTex;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    x -= (int)(character.velocity * gameTime.ElapsedGameTime.TotalSeconds);
                    character.currentTexture = LoadedContent.characterLeftTex;

                }

                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    x += (int)(character.velocity * gameTime.ElapsedGameTime.TotalSeconds);
                    character.currentTexture = LoadedContent.characterRightTex;
                }
            }

            if (x < 0)
            {
                x = 0;
            }

            if (y < 35)
            {
                y = 35;
            }

            if (y > AppConfig.appHeight - character.currentTexture.Height)
            {
                y = AppConfig.appHeight - character.currentTexture.Height;
            }

            if (x > AppConfig.appWidth - (character.currentTexture.Width / 3))
            {
                x = AppConfig.appWidth - (character.currentTexture.Width / 3);
            }

            character.UpdatePosition((int)x, (int)y);
        }

        public void Act(Human human, GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Act(Robot robot, GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
