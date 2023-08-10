Database View:
[ReviewMuseDatabaseSnapshot(1.0).pdf](https://github.com/YordanAntonov/ReviewMuseWebApplication/files/12315489/ReviewMuseDatabaseSnapshot.1.0.pdf)

# ReviewMuseWebApplication
 Final Project for ASP.NET Advanced course August 2023.
Test Account for the Stripe Payment:
Card Info : 4242 4242 4242 4242
MM/YY: 23/08
CVC : 123
---------------------------------------------------------
How it works:

The first user that we create in the application, we can take his email and paste it in ReviewMuse.Common.GeneralConstraints in the public const string FirstAdminSeedEmail = "";
It will automatically create this user as the first admin of the application.
There is seed data for books and authors in the ReviewMuse.Data.EntityConfigurations but they are commented because i had concern with the seeding of the data, we have too many mapping tables with hard coded guids inside, it might mess up the seeding.
Better to create new account become an editor and start adding new authors and books.
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
Users:
It is a simple application where normal Users can Log In and search for books of their choice if they are present in out web application, they can open them view the authors the ganres and also they can leave Reviews under the books.
Furthermore Normal Users can Add Books to their personal collection where they can find them more easly, and also they can set Book Status to one of 3 options ("Read", "Want To Read", "Reading") so they can keep track of their progress with the books.
Normal users can become editors via the Button in the nacigation bar, they will be redirected to Stripe Page where they will have to do a transaction of 200 bgn in order to support the website and to become editors for indefinite time period or till they violate terms of use and service.
Users if they choose can delete their own account!
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
Editors:
Editors are trustworthy people who chose to donate this big sum of money for our cause for the books :) We trust editors with their honesty to supervise the website for good content.
After succesfull transactions wanabee editors will be asked for some small additional data about them and after that they are becoming editors.
Editors can add new authors to the website aswell as many new books. The new additions of books and authors should be with correct info. It is checked by the admins.
Editors can delete offensive reviews or just reviews that are spam or not serious. (In short they are also moderators of the website).
They can edit only books that are added by themselfs, but everybody can edit information about the authors.
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
Admin:
Admin can do basically everything in the application, he can edit anybody's books.
Admin can delete reviews.
Admin can revoke Editorship of certain user, so to demote him to normal user.
Admin can promote other Editors to Admins aswell which is the highest position in the website moderatorship.
Admin can also delete or remove any user from the website, in very rare cases.
--------------------------------------------------------------------------------------------------------------------------------------------------------------------
