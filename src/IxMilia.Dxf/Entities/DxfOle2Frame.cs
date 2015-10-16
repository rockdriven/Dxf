// Copyright (c) IxMilia.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

// The contents of this file are automatically generated by a tool, and should not be directly modified.

using System;
using System.Collections.Generic;
using System.Linq;

namespace IxMilia.Dxf.Entities
{

    /// <summary>
    /// DxfOle2Frame class
    /// </summary>
    public partial class DxfOle2Frame : DxfEntity
    {
        public override DxfEntityType EntityType { get { return DxfEntityType.Ole2Frame; } }
        protected override DxfAcadVersion MinVersion { get { return DxfAcadVersion.R14; } }

        public int VersionNumber { get; set; }
        public string Description { get; set; }
        public DxfPoint UpperLeftCorner { get; set; }
        public DxfPoint LowerRightCorner { get; set; }
        public DxfOleObjectType ObjectType { get; set; }
        public DxfTileModeDescriptor TileMode { get; set; }
        public int BinaryDataLength { get; set; }
        public List<string> BinaryDataStrings { get; set; }

        public DxfOle2Frame()
            : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.VersionNumber = 0;
            this.Description = null;
            this.UpperLeftCorner = DxfPoint.Origin;
            this.LowerRightCorner = DxfPoint.Origin;
            this.ObjectType = DxfOleObjectType.Static;
            this.TileMode = DxfTileModeDescriptor.InTiledViewport;
            this.BinaryDataLength = 0;
            this.BinaryDataStrings = new List<string>();
        }

        protected override void AddValuePairs(List<DxfCodePair> pairs, DxfAcadVersion version, bool outputHandles)
        {
            base.AddValuePairs(pairs, version, outputHandles);
            pairs.Add(new DxfCodePair(100, "AcDbOle2Frame"));
            pairs.Add(new DxfCodePair(70, (short)(this.VersionNumber)));
            pairs.Add(new DxfCodePair(3, (this.Description)));
            pairs.Add(new DxfCodePair(10, UpperLeftCorner.X));
            pairs.Add(new DxfCodePair(20, UpperLeftCorner.Y));
            pairs.Add(new DxfCodePair(30, UpperLeftCorner.Z));
            pairs.Add(new DxfCodePair(11, LowerRightCorner.X));
            pairs.Add(new DxfCodePair(21, LowerRightCorner.Y));
            pairs.Add(new DxfCodePair(31, LowerRightCorner.Z));
            pairs.Add(new DxfCodePair(71, (short)(this.ObjectType)));
            pairs.Add(new DxfCodePair(72, (short)(this.TileMode)));
            pairs.Add(new DxfCodePair(90, (this.BinaryDataLength)));
            foreach (var item in BinaryDataStrings)
            {
                pairs.Add(new DxfCodePair(310, "item"));
            }

            pairs.Add(new DxfCodePair(1, "OLE"));
        }

        internal override bool TrySetPair(DxfCodePair pair)
        {
            switch (pair.Code)
            {
                case 3:
                    this.Description = (pair.StringValue);
                    break;
                case 10:
                    this.UpperLeftCorner.X = pair.DoubleValue;
                    break;
                case 20:
                    this.UpperLeftCorner.Y = pair.DoubleValue;
                    break;
                case 30:
                    this.UpperLeftCorner.Z = pair.DoubleValue;
                    break;
                case 11:
                    this.LowerRightCorner.X = pair.DoubleValue;
                    break;
                case 21:
                    this.LowerRightCorner.Y = pair.DoubleValue;
                    break;
                case 31:
                    this.LowerRightCorner.Z = pair.DoubleValue;
                    break;
                case 70:
                    this.VersionNumber = (int)(pair.ShortValue);
                    break;
                case 71:
                    this.ObjectType = (DxfOleObjectType)(pair.ShortValue);
                    break;
                case 72:
                    this.TileMode = (DxfTileModeDescriptor)(pair.ShortValue);
                    break;
                case 90:
                    this.BinaryDataLength = (pair.IntegerValue);
                    break;
                case 310:
                    this.BinaryDataStrings.Add((pair.StringValue));
                    break;
                default:
                    return base.TrySetPair(pair);
            }

            return true;
        }
    }

}