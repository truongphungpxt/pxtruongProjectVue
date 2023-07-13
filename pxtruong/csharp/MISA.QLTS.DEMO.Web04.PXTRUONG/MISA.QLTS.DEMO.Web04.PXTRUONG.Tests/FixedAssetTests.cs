using MISA.QLTS.DEMO.Web04.PXTRUONG.BL.FixedAssetBL;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Entities;
using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.MISAException;
using MISA.QLTS.DEMO.Web04.PXTRUONG.DL.FixedAssetDL;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.Tests
{
    [TestFixture]
    public class FixedAssetTests
    {
        ///// <summary>
        ///// AUthor:PXTRUONG(23/6/2023)
        ///// test giá trị trả về null
        ///// </summary>
        //[Test]
        //public void GetAll_NullT_ReturnNull()
        //{
        //    //Arrange
        //    var RecordCode = "AS-45555";
        //    var fakeFixedAssetDL = Substitute.For<IFixedAssetDL>();
           
        //    fakeFixedAssetDL.GetAll(RecordCode).ReturnsNull();

        //    var fixAssetBL = new FixedAssetBL(fakeFixedAssetDL);

        //    // Act
        //    var actualResult = fixAssetBL.GetAll(RecordCode);
        //    // Assert
        //    Assert.That(actualResult, Is.Null);
        //}
        ///// <summary>
        ///// AUthor:PXTRUONG(23/6/2023)
        ///// test giá trị trả về đúng
        ///// </summary>
        //[Test]
        //public void GetAll_validT_ReturnSucess()
        //{
        //    //Arrange
        //    var RecordCode = "AS-45555";
        //    var fakeFixedAssetDL = Substitute.For<IFixedAssetDL>();
        //    List<FixedAsset> expectResult = new List<FixedAsset>();
        //    fakeFixedAssetDL.GetAll(RecordCode).Returns(expectResult);
        //    var fixAssetBL = new FixedAssetBL(fakeFixedAssetDL);
        //    // Act
        //    var actualResult = fixAssetBL.GetAll(RecordCode);


        //    // Assert
        //    Assert.That(actualResult, Is.EqualTo(expectResult));
        //}
        ///// <summary>
        ///// AUthor:PXTRUONG(23/6/2023)
        ///// test giá trị trả về ex khi ko nhập giá trị requid
        ///// </summary>
        //[Test]
        //public void Insert_NullRequidValue_ThrowValidateException()
        //{
        //    //Arrange
        //    FixedAsset fixedAsset= new FixedAsset() { 
        //            FixedAssetID= new Guid(),
        //            FixedAssetCode=" ",
        //            Cost=0,
        //            DayUse=DateTime.Now,
        //            DepartmentID=new Guid(),
        //            FixedAssetCategoryID=new Guid(),
        //            Quantity=0,
        //            CreatedBy="Trường",
        //            CreatedDate=DateTime.Now,
        //            DepreciationRate=0,
        //            FixedAssetName="oto",
        //            PurchaseDate=DateTime.Now,
        //            ModifiedDate=DateTime.Now,
        //            TrackedYear=2023,
        //            ModifiedBy=""   
        //    };
        //    var fakeFixAssetDL = Substitute.For<IFixedAssetDL>();
        //    var fakeFixAssetBL= new FixedAssetBL(fakeFixAssetDL);

        //    //Act && Assert
        //    Assert.Throws<ValidateException>(() => { fakeFixAssetBL.Insert(fixedAsset); });
        //}
        ///// <summary>
        ///// AUthor:PXTRUONG(23/6/2023)
        ///// test giá trị trả về giá trị đúng 
        ///// </summary>
        //[Test]
        //public void Insert_Value_Success()
        //{
        //    //Arrange
        //    FixedAsset fixedAsset = new FixedAsset()
        //    {
        //        FixedAssetID = new Guid(),
        //        FixedAssetCode = "as-23445 ",
        //        Cost = 0,
        //        DayUse = DateTime.Now,
        //        DepartmentID = new Guid(),
        //        FixedAssetCategoryID = new Guid(),
        //        Quantity = 0,
        //        CreatedBy = "Trường",
        //        CreatedDate = DateTime.Now,
        //        DepreciationRate = 0,
        //        FixedAssetName = "oto",
        //        PurchaseDate = DateTime.Now,
        //        ModifiedDate = DateTime.Now,
        //        TrackedYear = 2023,
        //        ModifiedBy = ""
        //    };
        //    var fakeFixAssetDL = Substitute.For<IFixedAssetDL>();
        //    var fakeFixAssetBL = new FixedAssetBL(fakeFixAssetDL);
        //     fakeFixAssetDL.Insert(fixedAsset).Returns(1);
        //    //Act
        //    var actualResult = 1;
        //    //Assert
        //    Assert.That(actualResult, Is.EqualTo(actualResult));
        //}

    }
}
