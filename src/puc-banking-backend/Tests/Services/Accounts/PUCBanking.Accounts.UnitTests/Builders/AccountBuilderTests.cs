using PUCBanking.Accounts.API.Builders;
using PUCBanking.Shared.Validations;

namespace PUCBanking.Accounts.UnitTests.Builders {

    [TestClass]
    public class AccountBuilderTests {

        private readonly AccountBuilder _builder;
        public AccountBuilderTests() {
            _builder = new AccountBuilder();
        }

        [TestMethod]
        public void Build_WithoutCallCreateNewMethod_ThrowInvalidOperationException() {
            Assert.ThrowsException<InvalidOperationException>(() => _builder.Build());
        }

        [TestMethod]
        public void WithFirstName_WithoutCallCreateNewMethod_ThrowInvalidOperationException() {
            Assert.ThrowsException<InvalidOperationException>(() => _builder.WithFirstName(string.Empty));
        }

        [TestMethod]
        public void WithFirstName_ArgumentNull_ReturnsFailureWithArgumentNullError() {

            var buildResult = _builder.
                CreateNew().
                WithFirstName(null).
                Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(ArgumentNullError));
        }

        [TestMethod]
        public void WithFirstName_BlankFirstName_ReturnsFailureWithPropertyIsBlankError() {

            var buildResult = _builder.
                CreateNew().
                WithFirstName(string.Empty).
                Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(PropertyIsBlankError));
        }

        [TestMethod]
        public void WithFirstName_FirstNameLengthTooShort_ReturnsFailureWithPropertyLengthTooShortError() {

            var buildResult = _builder.
                CreateNew().
                WithFirstName("a").
                Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(PropertyLengthTooShortError));
        }

        [TestMethod]
        public void WithFirstName_FirstNameLengthTooLong_ReturnsFailureWithPropertyLengthTooLongError() {

            var buildResult = _builder.
                CreateNew().
                WithFirstName(StringUtils.CreateLongString("aa", 30)).
                Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(PropertyLengthTooLongError));
        }

        [TestMethod]
        public void WithFirstName_ValidFirstName_ReturnsSuccess() {

            var buildResult = _builder.
                CreateNew().
                WithFirstName("Batman").
                Build();

            Assert.IsTrue(buildResult.IsSuccess);
            Assert.AreEqual(buildResult.Value.FirstName, "Batman");
        }

        [TestMethod]
        public void WithLastName_WithoutCallCreateNewMethod_ThrowInvalidOperationException() {
            Assert.ThrowsException<InvalidOperationException>(() => _builder.WithLastName(string.Empty));
        }

        [TestMethod]
        public void WithLastName_ArgumentNull_ReturnsFailureWithArgumentNullError() {

            var buildResult = _builder.
                CreateNew().
                WithLastName(null).
                Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(ArgumentNullError));
        }

        [TestMethod]
        public void WithLastName_BlankLastName_ReturnsFailureWithPropertyIsBlankError() {

            var buildResult = _builder.
                CreateNew().
                WithLastName(string.Empty).
                Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(PropertyIsBlankError));
        }

        [TestMethod]
        public void WithLastName_LastNameLengthTooShort_ReturnsFailureWithPropertyLengthTooShortError() {

            var buildResult = _builder.
                CreateNew().
                WithLastName("a").
                Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(PropertyLengthTooShortError));
        }

        [TestMethod]
        public void WithLastName_LastNameLengthTooLong_ReturnsFailureWithPropertyLengthTooLongError() {

            var buildResult = _builder.
                CreateNew().
                WithLastName(StringUtils.CreateLongString("aa", 30)).
                Build();

            Assert.IsTrue(buildResult.IsFailed);
            Assert.IsInstanceOfType(buildResult.Errors[0], typeof(PropertyLengthTooLongError));
        }

        [TestMethod]
        public void WithLastName_ValidLastName_ReturnsSuccess() {

            var buildResult = _builder.
                CreateNew().
                WithLastName("Robson").
                Build();

            Assert.IsTrue(buildResult.IsSuccess);
            Assert.AreEqual(buildResult.Value.LastName, "Robson");
        }

        [TestMethod]
        public void WithEmail_WithoutCallCreateNewMethod_ThrowInvalidOperationException() {
            Assert.ThrowsException<InvalidOperationException>(() => _builder.WithEmail(""));
        }

        [TestMethod]
        public void WithEmail_ArgumentNull_ReturnsFailureWithArgumentNullError() {

            var result = _builder.
                CreateNew().
                WithEmail(null).
                Build();

            Assert.IsTrue(result.IsFailed);
            Assert.IsInstanceOfType(result.Errors[0], typeof(ArgumentNullError));
        }

        [TestMethod]
        public void WithEmail_BlankEmail_ReturnsFailureWithEmailIsBlankError() {

            var result = _builder.
                CreateNew().
                WithEmail(string.Empty).
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
        public void WithEmail_InvalidEmail_ReturnsFailureWithEmailIsInvalidError(string email) {

            var result = _builder.
                CreateNew().
                WithEmail(email).
                Build();

            Assert.IsTrue(result.IsFailed);
            Assert.IsInstanceOfType(result.Errors[0], typeof(EmailIsInvalidError));
        }

        [TestMethod]
        [DataRow("email@domain.com")]
        public void WithEmail_ValidEmail_ReturnsSuccess(string email) {

            var result = _builder.
                CreateNew().
                WithEmail(email).
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
            Assert.AreEqual(buildResult.Value.CardLimit, 5000);
        }
    }
}
