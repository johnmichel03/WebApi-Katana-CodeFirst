<article-edit>
  <div class="container default-margin">
    <form onsubmit="{saveArticle}">
      <div class="form-group">
        <label class="control-label" for="titleText">Title</label>
        <input type="text" value="{article.Title}" class="form-control" id="titleText" aria-describedby="titleHelpText" maxlength="100" required=""/>
        <span id="titleHelpText" class="help-block">Title of the article</span>
      </div>
      <div class="form-group">
        <label class="control-label" for="bodyText">Body</label>
        <textarea value="{article.Body}" class="form-control" rows="3"  id="bodyText" maxlength="1000" required="" ></textarea>
      </div>
      <div class="form-group">
        <button type="submit" class="btn btn-default">Save</button>
        <button type="submit" class="btn btn-default" onclick="{deleteArticle}">Delete</button>
      </div>
    </form>
  </div>
  <script>

    // To get article details

    var rootPath=window.location.hash.split('/');
    var articleId=rootPath[rootPath.length-1];
    var self = this;

    self.article={};
    $.get('http://localhost:9000/api/Articles/'+articleId, function(data, status){

    self.article=data;
    self.update()

    });


    //To update article
    this.saveArticle=function(){

    var self = this;
    self.article={'Title':titleText.value,'Body':bodyText.value,'AuthourName':'John'};
    //  console.log( self.article);
    $.post("http://localhost:9000/api/Articles/"+articleId,self.article,function(data, status){
    riot.route('article/articleList');
    });

    }


    self.deleteArticle=function(e){
    if(confirm("Are you want to delete this artical...!"))
    {
    console.log(e.item,+","+articleApiUrl);

    $.get(articleApiUrl+"DeleteArticle/"+articleId,
    function(data, status){
    riot.route('article/articleList');
    self.update();
    });
    }

    }
  </script>
</article-edit>