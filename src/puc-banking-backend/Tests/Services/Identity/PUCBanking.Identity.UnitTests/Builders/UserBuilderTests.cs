using PUCBanking.Identity.API.Builders;
using PUCBanking.Identity.API.Services;
using PUCBanking.Shared.Validations;

namespace PUCBanking.Identity.UnitTests.Builders {

    [TestClass]
    public class UserBuilderTests {

        private readonly UserBuilder _builder;
        public UserBuilderTests() {
            _builder = new UserBuilder(new PasswordService());
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
        public void WithPassword_WithoutCallCreateNewMethod_ThrowInvalidOperationException() {
            Assert.ThrowsException<InvalidOperationException>(() => _builder.WithPassword(""));
        }

        [TestMethod]
        public void WithPassword_ArgumentNull_ReturnsFailureWithArgumentNullError() {

            var result = _builder.
                CreateNew().
                WithPassword(null).
                Build();

            Assert.IsTrue(result.IsFailed);
            Assert.IsInstanceOfType(result.Errors[0], typeof(ArgumentNullError));
        }

        [TestMethod]
        public void WithPassword_BlankPassword_ReturnsFailureWithPasswordIsBlankError() {

            var result = _builder.
                CreateNew().
                WithPassword(string.Empty).
                Build();

            Assert.IsTrue(result.IsFailed);
            Assert.IsInstanceOfType(result.Errors[0], typeof(PasswordIsBlankError));
        }

        [TestMethod]
        [DataRow("pas")]
        [DataRow("pas123")]
        [DataRow("pass@123")]
        [DataRow("pass 123")]
        [DataRow("Pass123")]
        [DataRow("123")]
        [DataRow("@123")]
        [DataRow("Pass/123")]
        public void WithPassword_InvalidPassword_ReturnFailureWithPasswordIsInvalidError(string password) {

            var result = _builder.
                CreateNew().
                WithPassword(password).
                Build();

            Assert.IsTrue(result.IsFailed);
            Assert.IsInstanceOfType(result.Errors[0], typeof(PasswordIsInvalidError));
        }

        [TestMethod]
        [DataRow("Pass@123")]
        public void WithPassword_ValidPassword_ReturnSuccess(string password) {

            var result = _builder.
                CreateNew().
                WithPassword(password).
                Build();

            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public void EncryptPassword_WithoutCallCreateNewMethod_ThrowInvalidOperationException() {
            Assert.ThrowsException<InvalidOperationException>(() => _builder.EncryptPassword());
        }

        [TestMethod]
        public void EncryptPassword_WithoutAddPassword_ReturnsFailure() {
            var result = _builder
                .CreateNew()
                .EncryptPassword()
                .Build();

            Assert.IsTrue(result.IsFailed);
        }
    }
}
