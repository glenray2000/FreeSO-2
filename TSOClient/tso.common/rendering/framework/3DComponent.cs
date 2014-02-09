﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tso.common.rendering.framework.model;

namespace tso.common.rendering.framework
{
    public abstract class _3DComponent
    {
        public _3DScene Scene;

        public _3DComponent()
        {
        }

        private Vector3 m_Position = Vector3.Zero;
        private Vector3 m_Scale = Vector3.One;
        private float m_RotateX = 0.0f;
        private float m_RotateY = 0.0f;
        private float m_RotateZ = 0.0f;

        public GraphicsDevice Device
        {
            get
            {
                return Scene.Parent.Device;
            }
        }

        public float RotationX
        {
            get { return m_RotateX; }
            set
            {
                m_RotateX = value;
                m_WorldDirty = true;
            }
        }

        public float RotationY
        {
            get { return m_RotateY; }
            set
            {
                m_RotateY = value;
                m_WorldDirty = true;
            }
        }

        public float RotationZ
        {
            get { return m_RotateZ; }
            set
            {
                m_RotateZ = value;
                m_WorldDirty = true;
            }
        }

        public Vector3 Position
        {
            get { return m_Position; }
            set
            {
                m_Position = value;
                m_WorldDirty = true;
            }
        }

        public Vector3 Scale
        {
            get { return m_Scale; }
            set
            {
                m_Scale = value;
                m_WorldDirty = true;
            }
        }


        private Matrix m_World = Matrix.Identity;
        private bool m_WorldDirty = false;
        public Matrix World
        {
            get
            {
                if (m_WorldDirty)
                {
                    m_World = Matrix.CreateRotationX(m_RotateX) * Matrix.CreateRotationY(m_RotateY) * Matrix.CreateRotationZ(m_RotateZ) * Matrix.CreateScale(m_Scale) * Matrix.CreateTranslation(m_Position);
                    m_WorldDirty = false;
                }
                return m_World;
            }
        }



        private string m_StringID;
        public string ID
        {
            get { return m_StringID; }
            set { m_StringID = value; }
        }

        public virtual void Initialize()
        {
        }

        public abstract void Update(UpdateState state);
        public abstract void Draw(GraphicsDevice device);
        /// <summary>
        /// GraphicsDevice was reset.
        /// </summary>
        public abstract void DeviceReset(GraphicsDevice Device);


        public override string ToString()
        {
            if (m_StringID != null)
            {
                return m_StringID;
            }
            return base.ToString();
        }


        protected Matrix View
        {
            get
            {
                return Scene.Camera.View;
            }
        }

        protected Matrix Projection
        {
            get
            {
                return Scene.Camera.Projection;
            }
        }
    }
}
