#region License, Terms and Conditions
//
// Jayrock - A JSON-RPC implementation for the Microsoft .NET Framework
// Written by Atif Aziz (www.raboof.com)
// Copyright (c) Atif Aziz. All rights reserved.
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 2.1 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
// details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library; if not, write to the Free Software Foundation, Inc.,
// 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
//
#endregion

namespace Jayrock.Json.Conversion.Converters
{
    #region Imports

    using System;
    using NUnit.Framework;

    #endregion

    [ TestFixture ]
    public class TestStringExporter
    {
        [ Test ]
        public void Superclass()
        {
            Assert.IsInstanceOfType(typeof(ExporterBase), new StringExporter());
        }

        [ Test ]
        public void InputTypeIsString()
        {
            Assert.AreSame(typeof(string), (new StringExporter()).InputType);
        }

        [ Test ]
        public void ExportEmpty()
        {
            Assert.AreEqual(string.Empty, Export(string.Empty).ReadString());
        }

        [ Test ]
        public void ExportString()
        {
            Assert.AreEqual("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.", Export("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.").ReadString());
        }

        private static JsonReader Export(string value)
        {
            JsonRecorder writer = new JsonRecorder();
            JsonConvert.Export(value, writer);
            return writer.CreatePlayer();
        }
    }
}