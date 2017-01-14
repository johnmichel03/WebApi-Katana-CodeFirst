<menu-items>
  <nav class="navbar navbar-fixed-top navbar-inverse">
    <div class="container">
      <div class="navbar-header">
        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
          <span class="sr-only">Toggle navigation</span>
          <span class="icon-bar"></span>
          <span class="icon-bar"></span>
          <span class="icon-bar"></span>
        </button>
        <a class="navbar-brand" href="#">Pressford Consulting News</a>
      </div>
      <div id="navbar" class="collapse navbar-collapse">
        <ul class="nav navbar-nav">
          <li class="active" show="{ isEmployee }" >
            <a href="#article/articleList">Home</a>
          </li>
          <li>
            <a href="#about" show="{ isEmployee }" >About</a>
          </li>
          <li>
            <a href="#contact" show="{ isEmployee }">Contact</a>
          </li>
          <li>
            <a href="#article/articleCreate" show="{ isEmployee }" >Create</a>
          </li>

          <li>
            <a href="#article/articleReport" show="{ isEmployee }" >Report</a>
          </li>
          <li class="pull-right">
            <a href="#login" onclick="{checkLoginStatus}">{this.login}</a>
          </li>
        </ul>

      </div>
      <!-- /.nav-collapse -->
    </div>
    <!-- /.container -->
  </nav>
  <!-- /.navbar -->
  <script>

    this.checkLoginStatus=function(){
    console.log(this.login);
    
    if(this.login=="Sign In")
    localStorage.setItem("IsEmployee",undefined);
    console.log( localStorage.getItem("IsEmployee"));
   //this.login= this.login=="Sign Out"?"Sign Out":"Sign In";
   riot.route('/login');
    }
    

    if(localStorage.getItem("IsEmployee")=="Yes")
    {
    this.isEmployee=false;
    }
    else if(localStorage.getItem("IsEmployee")=="No")
    {
    this.isEmployee=true;
    }
    else
    {
    //this.login='Sign In';
    }

    this.on("mount",function(){
    //console.log(opts);
    // console.log("menu mounted");
    this.login= this.login=="Sign In"?"Sign Out":"Sign In";
    this.update()
    });

  </script>
</menu-items>