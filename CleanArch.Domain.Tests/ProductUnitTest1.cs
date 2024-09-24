using CleanArch.Domain.Entities;
using FluentAssertions;

namespace CleanArch.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 
                99, "product.jpg");
            action.Should()
                .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m,
                99, "product.jpg");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m,
                99, "product.jpg");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name too short. Name minimum 3 charecters.");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m,
                99, "product.jpg");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateProduct_WithNullNameValue_DomainExceptionNullName()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99m,
                99, "product.jpg");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "Product Name", "desc", 9.99m,
                99, "product.jpg");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description too short. Description minimum 5 charecters.");
        }

        [Fact]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m,
                99, "product.jpg");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required.");
        }

        [Fact]
        public void CreateProduct_WithNullDescriptionValue_DomainExceptionNullDescription()
        {
            Action action = () => new Product(1, "Product Name", null, 9.99m,
                99, "product.jpg");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativePriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1.00m,
                99, "product.jpg");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value.");
        }

        [Fact]
        public void CreateProduct_InvalidImageValue_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 11.00m,
               12, "A amizade sincera e verdadeira é um tesouro raro e precioso. É uma conexão que transcende o tempo, a distância e as circunstâncias. É um vínculo que se fortalece com cada risada compartilhada, cada segredo confiado, cada desafio enfrentado juntos.\r\n\r\nUma amizade sincera e verdadeira não é medida pelo tempo que passamos juntos, mas pela profundidade do vínculo que compartilhamos. Não é baseada em conveniência ou benefício mútuo, mas em um amor genuíno e respeito mútuo. É uma relação que nos permite sermos nós mesmos, sem medo de julgamento ou rejeição.\r\n\r\nNessa amizade, encontramos conforto em silêncios tranquilos e alegria em risadas estrondosas. Encontramos apoio em tempos de luta e celebração em tempos de alegria. Encontramos alguém que nos entende, mesmo quando palavras não são ditas.\r\n\r\nUma amizade sincera e verdadeira é um refúgio seguro, um lugar onde podemos ser vulneráveis, expressar nossos medos e esperanças, nossas alegrias e tristezas. É um lugar onde somos vistos, ouvidos e valorizados por quem somos, não pelo que fazemos ou temos.\r\n\r\nEssa amizade nos desafia a crescer, a nos tornarmos melhores, a viver nossas vidas com autenticidade e coragem. Nos inspira a sonhar mais alto, a lutar mais forte, a amar mais profundamente.\r\n\r\nA amizade sincera e verdadeira é, em sua essência, um ato de amor - um amor que é livre, incondicional e eterno. É um presente que, uma vez recebido, torna-se uma parte inseparável de nós, enriquecendo nossas vidas com sua presença constante e inabalável. É, sem dúvida, uma das maiores bênçãos da vida.");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name. Image name maximum 250 charecters.");
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, "");
            action.Should()
                .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, null);
            action.Should()
                .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m,
                99, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }



        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_DomainExceptionNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 11.00m,
               value, "product.jpg");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }


    }
}
