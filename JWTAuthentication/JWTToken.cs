using JWTAuth.Model;
using JWTAuthentication.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace JWTAuthentication
{
    public class JWTToken
    {
        public JwtTokenResponse generateToken(PersonModel credentials)
        {
            JwtTokenResponse resonse;
            try


            {
                //check user availabilty in our system
                
                // call db to check user available


                if (credentials.Name == "user" && credentials.Password == "1234")
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("SecureKeyForBlazorCourseSecureKeyForBlazorCourse");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, credentials.Name)
                        }),
                        Expires = DateTime.Now.AddHours(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);
                    resonse = new JwtTokenResponse { Token = tokenString, Expiration = tokenDescriptor.Expires.Value };
                    return resonse;
                }
                else
                {

                    resonse = new JwtTokenResponse();
                    return resonse;
                }
            }
            catch (Exception ex) {
                resonse = new JwtTokenResponse();
                return resonse;

            }

        }
    }
}
