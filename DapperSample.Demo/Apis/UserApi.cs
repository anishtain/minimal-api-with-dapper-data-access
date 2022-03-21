namespace DapperSample.Demo.Apis
{
    public static class UserApi
    {
        public static void ConfigureUserApi(this WebApplication application)
        {
            application.MapGet("users/getall", GetUsers);
            application.MapGet("users/get/{id}", GetUser);

            application.MapPost("users/create", Create);
            application.MapPost("users/update", Update);
            application.MapPost("users/delete/{id}", Delete);
        }

        private static async Task<IResult> GetUsers(IUserData data)
        {
            try
            {
                return Results.Ok(await data.GetAll());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetUser(int id, IUserData data)
        {
            try
            {
                var result = await data.GetById(id);
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> Create(User user, IUserData data)
        {
            try
            {
                await data.Insert(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> Update(User user, IUserData data)
        {
            try
            {
                await data.Update(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> Delete(int id, IUserData data)
        {
            try
            {
                await data.Delete(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
