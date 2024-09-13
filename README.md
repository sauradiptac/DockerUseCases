# DockerUseCases
### Use Case 1
WebContainer is a .NET Core 6 MVC Web Application. The Home page has a link called <code>Categories</code> in the Header. When you click on that it actually fetches list of categories from an external Azure SQL server. Their are other CRUD operations possible from the Category/Index page. The <code>Category</code> model is present in the <code>Models</code> class library. The <code>DataAccess</Code> class library provides the functionalities to access the external database.
#### Docker steps used in sequence
<ol>
  <li>
    Build a linux base image for WebContainer
    <ol>
      <li>Navigate to DockerUseCases folder</li>
      <li>
        <code>docker build -f WebContainer/Dockerfile .</code>
        This is required as Dockerfile resides inside WebContainer but WebContainer.csproj needs the other class libraries like Models and DataAccess to build.
      </li>
      <li>
        <code>docker image ls</code>
        Most probably there will be an image which was just created and has no name<code>None</code>
      </li>
      <li>
        Create a repo in Docker Hub like sauradipta/webcontainer
      </li>
      <li>
        Tag the newly created image. <code>docker tag [image id] sauradipta/webcontainer </code>
        Tag name if not mentioned will be considered as <code>latest</code>.
      </li>
      <li>
        Push the newly tagged image. <code>docker push [image name:tag] sauradipta/webcontainer </code>
        Tag if not mentioned will be considered as <code>latest</code>
      </li>
    </ol>
  </li>
  <li>
    Run the container fro the image uploaded in docker hub.
    <code>docker run --name webContainer -p 5000:80 sauradipta/webcontainer</code>
  </li>
<li>
    Open http://localhost:5000 in a browser.
</li>
</ol>
