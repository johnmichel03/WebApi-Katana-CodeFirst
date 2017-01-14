<article-create>
  <div class="container default-margin">
    <form onsubmit="{saveArticle}">
      <div class="form-group">
        <label class="control-label" for="titleText">Title</label>
        <input type="text" class="form-control" id="titleText" aria-describedby="titleHelpText" maxlength="100" required=""/>
        <span id="titleHelpText" class="help-block">Title of the article</span>
      </div>
      <div class="form-group">
        <label class="control-label" for="bodyText">Body</label>
        <textarea class="form-control" rows="3"  id="bodyText" maxlength="1000" required="" ></textarea>
      </div>
      <div class="form-group">
        <button type="submit" class="btn btn-default">Save</button>
      </div>
    </form>
  </div>
  <script>
    this.saveArticle=function(){
    var self = this;
    self.article={'Title':titleText.value,'Body':bodyText.value,'AuthourName':'John'};
    $.post("http://localhost:9000/api/Articles/",
    self.article,
    function(data, status){
    // alert("Data: " + data + "\nStatus: " + status);
    riot.route('article/articleList');
    });
    }
  </script>
</article-create>