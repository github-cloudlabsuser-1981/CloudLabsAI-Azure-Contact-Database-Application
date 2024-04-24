[TestFixture]
public class UserControllerTests
{
    private Mock<IUserRepository> _mockRepo;
    private UserController _controller;

    [SetUp]
    public void SetUp()
    {
        _mockRepo = new Mock<IUserRepository>();
        _controller = new UserController(_mockRepo.Object);
    }

    [Test]
    public void Index_ReturnsViewWithUsers()
    {
        var users = new List<User> { new User { Id = 1, Name = "Test", Email = "test@test.com" } };
        _mockRepo.Setup(repo => repo.GetAll()).Returns(users);

        var result = _controller.Index() as ViewResult;
        var model = result.Model as List<User>;

        Assert.That(result, Is.Not.Null);
        Assert.That(model, Is.EquivalentTo(users));
    }

    [Test]
    public void Details_ReturnsUser()
    {
        var user = new User { Id = 1, Name = "Test", Email = "test@test.com" };
        _mockRepo.Setup(repo => repo.Get(1)).Returns(user);

        var result = _controller.Details(1) as ViewResult;
        var model = result.Model as User;

        Assert.That(result, Is.Not.Null);
        Assert.That(model, Is.EqualTo(user));
    }

    // Similar tests can be written for Create, Edit, and Delete methods
}
