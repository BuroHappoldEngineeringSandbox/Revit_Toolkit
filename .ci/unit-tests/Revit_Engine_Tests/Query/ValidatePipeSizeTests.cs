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
using BH.oM.Adapters.Revit.Elements;
using NUnit.Framework;
using System.Collections.Generic;

namespace BH.Tests.Engine.Adapters.Revit.Query
{
    [TestFixture]
    public class ValidatePipeSizeTests
    {
        /***************************************************/
        /****          Validate(List<PipeSize>)         ****/
        /***************************************************/

        [Test]
        public void Validate_ValidUniqueSizes_ReturnsTrue()
        {
            var sizes = new List<PipeSize>
            {
                new PipeSize { NominalDiameter = 0.05, InnerDiameter = 0.048, OuterDiameter = 0.060 },
                new PipeSize { NominalDiameter = 0.10, InnerDiameter = 0.097, OuterDiameter = 0.114 },
            };

            var result = sizes.Validate();

            Assert.That(result.Item1, Is.True);
            Assert.That(result.Item2, Has.Count.EqualTo(2));
        }

        [Test]
        public void Validate_ValidSizes_ReturnsSortedByNominalDiameter()
        {
            var sizes = new List<PipeSize>
            {
                new PipeSize { NominalDiameter = 0.10, InnerDiameter = 0.097, OuterDiameter = 0.114 },
                new PipeSize { NominalDiameter = 0.05, InnerDiameter = 0.048, OuterDiameter = 0.060 },
            };

            var result = sizes.Validate();

            Assert.That(result.Item1, Is.True);
            Assert.That(result.Item2[0].NominalDiameter, Is.LessThan(result.Item2[1].NominalDiameter));
        }

        [Test]
        public void Validate_DuplicateSizes_DeduplicatesAndReturnsTrue()
        {
            var sizes = new List<PipeSize>
            {
                new PipeSize { NominalDiameter = 0.05, InnerDiameter = 0.048, OuterDiameter = 0.060 },
                new PipeSize { NominalDiameter = 0.05, InnerDiameter = 0.048, OuterDiameter = 0.060 },
            };

            var result = sizes.Validate();

            Assert.That(result.Item1, Is.True);
            Assert.That(result.Item2, Has.Count.EqualTo(1));
        }

        [Test]
        public void Validate_InnerDiameterLargerThanOuter_ReturnsFalse()
        {
            var sizes = new List<PipeSize>
            {
                new PipeSize { NominalDiameter = 0.05, InnerDiameter = 0.080, OuterDiameter = 0.060 },
            };

            var result = sizes.Validate();

            Assert.That(result.Item1, Is.False);
            Assert.That(result.Item2, Is.Null);
        }

        [Test]
        public void Validate_ZeroNominalDiameter_ReturnsFalse()
        {
            var sizes = new List<PipeSize>
            {
                new PipeSize { NominalDiameter = 0.0, InnerDiameter = 0.048, OuterDiameter = 0.060 },
            };

            var result = sizes.Validate();

            Assert.That(result.Item1, Is.False);
        }

        [Test]
        public void Validate_NullCollection_ReturnsFalse()
        {
            List<PipeSize>? sizes = null;

            var result = sizes!.Validate();

            Assert.That(result.Item1, Is.False);
            Assert.That(result.Item2, Is.Null);
        }

        [Test]
        public void Validate_EmptyCollection_ReturnsTrue()
        {
            var result = new List<PipeSize>().Validate();

            Assert.That(result.Item1, Is.True);
            Assert.That(result.Item2, Is.Empty);
        }
    }
}
