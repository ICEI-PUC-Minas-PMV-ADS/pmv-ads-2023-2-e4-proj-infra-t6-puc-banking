using PUCBanking.Cards.API.Builders;
using PUCBanking.Shared.Validations;

namespace PUCBanking.Cards.UnitTests.Builders {

    [TestClass]
    public class CreditCardBuilderTests {

        private readonly CreditCardBuilder _builder;
        public CreditCardBuilderTests() {
            _builder = new CreditCardBuilder();
        }

        [TestMethod]
        public void Build_WithoutCallCreateNewMethod_ThrowInvalidOperationException() {
            Assert.ThrowsException<InvalidOperationException>(() => _builder.Build());
        }

        [TestMethod]
        public void WithHolderName_WithoutCallCreateNewMethod_ThrowInvalidOperationException() {
            Assert.ThrowsException<InvalidOperationException>(() => _builder.WithHolderName(string.Empty));
        }

        [TestMethod]
        public void WithHolderName_ArgumentNull_ReturnsFailureWithArgumentNullError() {

            var buildResult = _builder.
                CreateNew().
                WithHolderName(null).
                Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(ArgumentNullError));
        }

        [TestMethod]
        public void WithHolderName_BlankHolderName_ReturnsFailureWithPropertyIsBlankError() {

            var buildResult = _builder.
                CreateNew().
                WithHolderName(string.Empty).
                Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(PropertyIsBlankError));
        }

        [TestMethod]
        public void WithHolderName_HolderNameLengthTooShort_ReturnsFailureWithPropertyLengthTooShortError() {

            var buildResult = _builder.
                CreateNew().
                WithHolderName("a").
                Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(PropertyLengthTooShortError));
        }

        [TestMethod]
        public void WithHolderName_HolderNameLengthTooLong_ReturnsFailureWithPropertyLengthTooLongError() {

            var buildResult = _builder.
                CreateNew().
                WithHolderName(StringUtils.CreateLongString("aa", 100)).
                Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(PropertyLengthTooLongError));
        }

        [TestMethod]
        public void WithHolderName_ValidHolderName_ReturnsSuccess() {

            var buildResult = _builder.
                CreateNew().
                WithHolderName("Bruce Wayne").
                Build();

            Assert.IsTrue(buildResult.IsSuccess);
            Assert.AreEqual(buildResult.Value.HolderName, "Bruce Wayne");
        }

        [TestMethod]
        public void WithUserEmail_WithoutCallCreateNewMethod_ThrowInvalidOperationException() {
            Assert.ThrowsException<InvalidOperationException>(() => _builder.WithUserEmail(""));
        }

        [TestMethod]
        public void WithUserEmail_ArgumentNull_ReturnsFailureWithArgumentNullError() {

            var result = _builder.
                CreateNew().
                WithUserEmail(null).
                Build();

            Assert.IsTrue(result.IsFailed);
            Assert.IsInstanceOfType(result.Errors[0], typeof(ArgumentNullError));
        }

        [TestMethod]
        public void WithUserEmail_BlankEmail_ReturnsFailureWithEmailIsBlankError() {

            var result = _builder.
                CreateNew().
                WithUserEmail(string.Empty).
                Build();

            Assert.IsTrue(result.IsFailed);
            Assert.IsInstanceOfType(result.Errors[0], typeof(EmailIsBlankError));
        }

        [TestMethod]
        [DataRow("abc.com")]
        [DataRow("email @teste.com")]
        [DataRow("email@gento")]
        [DataRow("@teste.com")]
        [DataRow("@teste@.com")]
        public void WithUserEmail_InvalidEmail_ReturnsFailureWithEmailIsInvalidError(string email) {

            var result = _builder.
                CreateNew().
                WithUserEmail(email).
                Build();

            Assert.IsTrue(result.IsFailed);
            Assert.IsInstanceOfType(result.Errors[0], typeof(EmailIsInvalidError));
        }

        [TestMethod]
        [DataRow("email@domain.com")]
        public void WithUserEmail_ValidEmail_ReturnsSuccess(string email) {

            var result = _builder.
                CreateNew().
                WithUserEmail(email).
                Build();

            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public void WithInitialCardLimit_WithoutCallCreateNewMethod_ThrowInvalidOperationException() {
            Assert.ThrowsException<InvalidOperationException>(() => _builder.WithInitialCardLimit(0));
        }

        [TestMethod]
        public void WithInitialCardLimit_NegativeCardLimitValue_ReturnsFailureWithPropertyValueTooSmallError() {
            var buildResult = _builder
                .CreateNew()
                .WithInitialCardLimit(-1)
                .Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(PropertyValueTooSmallError));
        }

        [TestMethod]
        public void WithInitialCardLimit_TooLongCardLimitValue_ReturnsFailureWithPropertyValueTooLongError() {
            var buildResult = _builder
                .CreateNew()
                .WithInitialCardLimit(10001)
                .Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(PropertyValueTooLongError));
        }

        [TestMethod]
        public void WithInitialCardLimit_ValidCardLimitValue_ReturnsSucess() {
            var buildResult = _builder
                .CreateNew()
                .WithInitialCardLimit(5000)
                .Build();

            Assert.IsTrue(buildResult.IsSuccess);
            Assert.AreEqual(buildResult.Value.CreditLimit, 5000);
        }
    }
}

