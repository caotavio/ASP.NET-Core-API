CREATE PROCEDURE spCreateAddress
    @Id UNIQUEIDENTIFIER,
	@CustomerId UNIQUEIDENTIFIER,
    @Street VARCHAR(60),
	@Number VARCHAR(10),
	@Complement VARCHAR(40),
	@City VARCHAR(60),
	@County CHAR(60),
    @Country CHAR(60),
	@PostCode CHAR(8),
	@Type INT
AS
    INSERT INTO [Address] (
        [Id],
        [CustomerId],
        [Street],
        [Number],
        [Complement],
        [City],
        [County],
        [Country],
        [PostCode],
        [Type]
    ) VALUES (
        @Id,
        @CustomerId,
        @Street,
        @Number,
        @Complement,
        @City,
        @County,
        @Country,
        @PostCode,
        @Type
    )