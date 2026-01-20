using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ColorObjects
{
    class colorObject
    {
        Texture2D _tx;
        Color _myColor;
        bool _visible = true;

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public Color MyColor
        {
            get { return _myColor; }
            set { _myColor = value; }
        }
        Vector2 _position;
        bool _chosen = false;
        public Color _HoverColor = new Color(new Vector3(0, 0, 0));
        Color CurrentColor;
        public bool Chosen
        {
            get { return _chosen; }
            set { _chosen = value; }
        }
        public Rectangle Target
        {
            get { return new Rectangle((int)_position.X, (int)_position.Y, _tx.Width, _tx.Height); }
       }

        public colorObject(Vector2 pos, Texture2D tx, Color c)
        {
            _position = pos;
            _tx = tx;
            _myColor = c;
            CurrentColor = c;
            _HoverColor = new Color(c,127);
        }
        public void update(GameTime t) 
        {
            if (InputEngine.IsMouseLeftClick())
                if (Target.Contains(InputEngine.MousePosition))
                {
                    _chosen = true;
                    CurrentColor = new Color(MyColor, 128);
                }
            if (Target.Contains(InputEngine.MousePosition) && !_chosen)
                CurrentColor = _HoverColor;
            else if (!Target.Contains(InputEngine.MousePosition) && !_chosen)
                CurrentColor = MyColor;


        }

        public void Draw(SpriteBatch sp)
        {
            sp.Draw(_tx, Target, CurrentColor);
        }
    }
}
