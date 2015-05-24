/*
Copyright 2014 Alex Dyachenko

This file is part of the MPIR Library.

The MPIR Library is free software; you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published
by the Free Software Foundation; either version 3 of the License, or (at
your option) any later version.

The MPIR Library is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
License for more details.

You should have received a copy of the GNU Lesser General Public License
along with the MPIR Library.  If not, see http://www.gnu.org/licenses/.  
*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MPIR.Tests.HugeRationalTests
{
    [TestClass]
    public class Assignment
    {
        [TestMethod]
        public void RationalAssignCopy()
        {
            using (var a = new HugeRational("-222509832503450298345029835740293845720/115756986668303657898962467957"))
            using (var b = new HugeRational())
            {
                b.Value = a;
                Assert.AreEqual("-222509832503450298345029835740293845720/115756986668303657898962467957", b.ToString());
            }
        }

        [TestMethod]
        public void RationalSwap()
        {
            using (var a = new HugeRational("-222509832503450298345029835740293845720/115756986668303657898962467957"))
            using (var b = new HugeRational("2039847290878794872059384789347534534/590872612825179551336102196593"))
            {
                var aValue = a._value();
                var bValue = b._value();
                a.Swap(b);
                Assert.AreEqual(bValue, a._value());
                Assert.AreEqual(aValue, b._value());
            }
        }

        [TestMethod]
        public void RationalCompoundOperators()
        {
            using (var a = new HugeRational("938475092834705928347523452345/115756986668303657898962467957"))
            {
                a.Value += 1;
                a.Value *= 10;
                Assert.AreEqual("10542320795030095862464859203020/115756986668303657898962467957", a.ToString());
            }
        }

        [TestMethod]
        public void RationalAssignFloat()
        {
            using (var a = new HugeFloat("9363833093638312937.25"))
            using (var b = new HugeRational())
            {
                b.SetTo(a);
                Assert.AreEqual("37455332374553251749/4", b.ToString());
            }
        }

        [TestMethod]
        public void RationalAssignInt()
        {
            using (var a = new HugeInt("222509832503450298345029835740293845720"))
            using (var b = new HugeRational("1/3"))
            {
                b.SetTo(a);
                Assert.AreEqual("222509832503450298345029835740293845720/1", b.ToString());
            }
        }

        [TestMethod]
        public void RationalAssignInt2()
        {
            using (var a = new HugeInt("222509832503450298345029835740293845719"))
            using (var d = new HugeInt("115756986668303657898962467957"))
            using (var b = new HugeRational("1/3"))
            {
                b.SetTo(a, d);
                Assert.AreEqual("222509832503450298345029835740293845719/115756986668303657898962467957", b.ToString());
                b.SetTo(b.Numerator - b.Denominator, b.Denominator * 5);
                Assert.AreEqual(a - d, b.Numerator);
                Assert.AreEqual(d * 5, b.Denominator);
            }
        }

        [TestMethod]
        public void RationalAssignFloat2()
        {
            using(var a = new HugeFloat("222509832503450298342455029.125"))
            using(var b = new HugeRational("1/3"))
            {
                b.SetTo(a);
                Assert.AreEqual("1780078660027602386739640233/8", b.ToString());
            }
        }
        //more tests coming here
    }
}
