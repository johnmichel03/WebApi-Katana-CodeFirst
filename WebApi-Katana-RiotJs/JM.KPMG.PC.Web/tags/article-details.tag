<article-details>

  <div class="container row news-details default-margin">
    <h1>{article.Title}</h1>
    <div>{article.Body}</div>
    <div>
      <a id="likeOrUnlike" class="btn btn-default"  onclick="{likeArticle}">{likeOrUnlike}</a>
    </div>
    <br></br>
    <div class="row">
      <a class="btn btn-default"  href="#article/articleList">Back</a>
    </div>
    
  </div>

  <script>
    // to show the articale details

    var rootPath=window.location.hash.split('/');
    var articleId=rootPath[rootPath.length-1];
    //console.log(articleId);
    var self = this;
    self.article={};
    this.on("mount",function(){
    $.get('http://localhost:9000/api/Articles/'+articleId, function(data, status){
    self.article=data;
    // console.log( self.article);
    self.update()
    });
    });

    // Like or un like article

    this.likeOrUnlike='Like';
    this.likeArticle=function(){
    var likeStatus=false;
    if(this.likeOrUnlike =='Like')
    {
    likeStatus=true;
    this.likeOrUnlike='Unlike'
    }
    else
    {
    likeStatus=false;
    this.likeOrUnlike='Like'
    }

    $.get('http://localhost:9000/api/Articles/LikeArticle/'+articleId+'/'+likeStatus,
    function(data, status){
    self.update()
    });
    }

   
  </script>
</article-details>
