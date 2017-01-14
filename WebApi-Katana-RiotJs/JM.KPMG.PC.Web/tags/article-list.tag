<article-list>

  <div class="row default-margin">
    <news each="{articleList }" />
  </div>

  <script>
    
   // this.on("mount",function(){ });
    
    var self = this;
    self.articleList=[];
    $.get('http://localhost:9000/api/Articles', function(data, status){
    self.articleList=data;
    //console.log( self.articleList);
    self.update()
    })

  </script>

</article-list>

<news>
  <div class="col-xs-6">
    <h2>
      {Title}
    </h2>
    <p>
      <trim value="{Body}" articleId="{Id}" AuthourName="{AuthourName}"></trim>
    </p>
    <p>
      <a class="btn btn-default" href="#article/articleDetails/{Id}" articleId="{Id}" onclick="{parent.remove}">View more>>></a>
    </p>

    <p show="{showButtons}">
      <a class="btn btn-default" href="#article/articleEdit/{Id}" articleId="{Id}" onclick="{parent.remove}">Edit/Delete</a>
    </p>

    <!--<p show="{showButtons}">
      <a class="btn btn-default" onclick="{deleteArticle}">Delete</a>
    </p>-->
  </div>
  <script>

    var self=this;

    self.showButtons=false;

    if(localStorage.getItem("IsEmployee")=="No")
    {
    self.showButtons=true;
    }

    

  </script>
</news>

<trim>
  <p>
    {opts.value.substr(0,50)}
  </p>
  <p>
    <h11>
      <span>Authour: </span>{AuthourName}
    </h11>
  </p>
  <script>
    <!--this.gotoDetails=function(id){
    e.preventDefault();
    consle.log(id);
    riot.route('article/id/articleDetails');
    }-->
  </script>
</trim>


