/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2026, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *
 * The BHoM is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3.0 of the License, or
 * (at your option) any later version.
 *
 * The BHoM is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.
 */

using BH.Engine.Adapters.Revit;
using NUnit.Framework;

namespace BH.Tests.Engine.Adapters.Revit.Query
{
    [TestFixture]
    public class FamilyTypeFullNameTests
    {
        /***************************************************/
        /****        FamilyTypeFullName(string, string) ****/
        /***************************************************/

        [Test]
        public void FamilyTypeFullName_ValidInputs_ReturnsFormattedString()
        {
            string result = "Rectangular Duct".FamilyTypeFullName("300x200");
            Assert.That(result, Is.EqualTo("Rectangular Duct: 300x200"));
        }

        [Test]
        public void FamilyTypeFullName_NullFamilyName_ReturnsNull()
        {
            string? familyName = null;
            string result = familyName!.FamilyTypeFullName("300x200");
            Assert.That(result, Is.Null);
        }

        [Test]
        public void FamilyTypeFullName_NullTypeName_ReturnsNull()
        {
            string result = "Rectangular Duct".FamilyTypeFullName(null!);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void FamilyTypeFullName_EmptyFamilyName_ReturnsNull()
        {
            string result = "".FamilyTypeFullName("300x200");
            Assert.That(result, Is.Null);
        }

        [Test]
        public void FamilyTypeFullName_EmptyTypeName_ReturnsNull()
        {
            string result = "Rectangular Duct".FamilyTypeFullName("");
            Assert.That(result, Is.Null);
        }

        [Test]
        public void FamilyTypeFullName_WhitespaceFamilyName_ReturnsNull()
        {
            string result = "   ".FamilyTypeFullName("300x200");
            Assert.That(result, Is.Null);
        }
    }
}
