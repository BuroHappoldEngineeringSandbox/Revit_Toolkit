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
    public class FamilyNameTests
    {
        /***************************************************/
        /****           FamilyName(string)              ****/
        /***************************************************/

        [Test]
        public void FamilyName_ValidFullName_ReturnsFamilyName()
        {
            string result = "Rectangular Duct: 300x200".FamilyName();
            Assert.That(result, Is.EqualTo("Rectangular Duct"));
        }

        [Test]
        public void FamilyName_FullNameWithSpaces_TrimsResult()
        {
            string result = "  My Family  :  My Type  ".FamilyName();
            Assert.That(result, Is.EqualTo("My Family"));
        }

        [Test]
        public void FamilyName_NoColon_ReturnsNull()
        {
            string result = "NoColonHere".FamilyName();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void FamilyName_EmptyString_ReturnsNull()
        {
            string result = "".FamilyName();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void FamilyName_NullString_ReturnsNull()
        {
            string? input = null;
            string result = input!.FamilyName();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void FamilyName_ColonAtStart_ReturnsNull()
        {
            // index == 0 so condition index <= 0 → return null
            string result = ":TypeOnly".FamilyName();
            Assert.That(result, Is.Null);
        }
    }
}
