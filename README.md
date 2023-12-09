# chat-app-with-user-management
Project for ZSiSK, by Marian Stopyra and Krzysztof Tofilski


Used technologies:
- Vue.Js
- Vuetify
- ASP.NET
- C#
- Pinia
- Axios
- Bootstrap
- NuGet packages:
    - SQLite
    - Microsoft.AspNetCore.Authentication.JwtBearer
    - Microsoft.EntityFrameworkCore.Sqlite
    - Microsoft.EntityFrameworkCore.Tools



Before running this:
1. install the Long Time Support version of Node.Js
2. install Visual Studio Community
Inside the frontend project folder (musicCatalogVueFrontend/):
3. npm install @vue/cli
4. npm install vuetify
5. npm install pinia
6. npm install axios
In case of dependency errors, install the above with the --force flag

You might also need to install the following:
7. npm install -g @vue/cli-service
8. npm install -g @vue/cli-plugin-babel
9. npm install -g @vue/cli-plugin-e2e-cypress
10. npm install -g @vue/cli-plugin-pwa
11. npm install -g @vue/cli-plugin-typescript
12. npm install -g @vue/cli-plugin-unit-jest
13. npm install -g vue-cli-plugin-axios
14. npm install -g vue-cli-plugin-bootstrap
15. npm install -g vue-cli-plugin-pinia
16. npm install -g vue-cli-plugin-vuetify

To run this:
1. start up backend by building solution (musicCatalogDotNetAPI.sln) in Visual Studio
2. start up frontend by running 'vue serve' (or 'npm run serve') in musicCatalogVueFrontend/
3. connect to localhost on port 8080, or on whichever port Vue-CLI deployed it on