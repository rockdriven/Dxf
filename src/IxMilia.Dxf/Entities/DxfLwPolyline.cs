﻿// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using IxMilia.Dxf.Collections;

namespace IxMilia.Dxf.Entities
{
    public partial class DxfLwPolyline
    {
        private ListNonNullWithMinimum<DxfLwPolylineVertex> _vertices = new ListNonNullWithMinimum<DxfLwPolylineVertex>(2);

        public IList<DxfLwPolylineVertex> Vertices { get { return _vertices; } }

        /// <summary>
        /// Creates a new LW polyline entity with the specified vertices.  NOTE, at least 2 vertices must be specified.
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <param name="vertices">The vertices to add.</param>
        public DxfLwPolyline(IEnumerable<DxfLwPolylineVertex> vertices)
            : this()
        {
            foreach (var vertex in vertices)
            {
                _vertices.Add(vertex);
            }

            _vertices.ValidateCount();
        }

        internal override DxfEntity PopulateFromBuffer(DxfCodePairBufferReader buffer)
        {
            while (buffer.ItemsRemain)
            {
                var pair = buffer.Peek();
                if (pair.Code == 0)
                {
                    break;
                }

                while (this.TrySetExtensionData(pair, buffer))
                {
                    pair = buffer.Peek();
                }

                if (pair.Code == 0)
                {
                    break;
                }

                switch (pair.Code)
                {
                    // vertex-specific pairs
                    case 10:
                        // start a new vertex
                        Vertices.Add(new DxfLwPolylineVertex());
                        Vertices.Last().X = pair.DoubleValue;
                        break;
                    case 20:
                        Vertices.Last().Y = pair.DoubleValue;
                        break;
                    case 40:
                        Vertices.Last().StartingWidth = pair.DoubleValue;
                        break;
                    case 41:
                        Vertices.Last().EndingWidth = pair.DoubleValue;
                        break;
                    case 42:
                        Vertices.Last().Bulge = pair.DoubleValue;
                        break;
                    case 91:
                        Vertices.Last().Identifier = pair.IntegerValue;
                        break;
                    // all other pairs
                    case 39:
                        Thickness = pair.DoubleValue;
                        break;
                    case 43:
                        ConstantWidth = pair.DoubleValue;
                        break;
                    case 70:
                        Flags = pair.ShortValue;
                        break;
                    case 210:
                        ExtrusionDirection.X = pair.DoubleValue;
                        break;
                    case 220:
                        ExtrusionDirection.Y = pair.DoubleValue;
                        break;
                    case 230:
                        ExtrusionDirection.Z = pair.DoubleValue;
                        break;
                    default:
                        if (!base.TrySetPair(pair))
                        {
                            ExcessCodePairs.Add(pair);
                        }
                        break;
                }

                buffer.Advance();
            }

            return PostParse();
        }
    }
}
