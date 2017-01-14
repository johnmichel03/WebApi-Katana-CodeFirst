<login >
  <!--<div class="container login">
    <form class="form-signin" onsubmit="{onSubmit}">
      <h2 class="form-signin-heading">Please sign in</h2>
      <label for="inputEmail" class="sr-only">Email address</label>
      <input type="email" id="inputEmail" name="inputEmail" class="form-control" placeholder="Email address" required="" autofocus=""/>
      <label for="inputPassword" class="sr-only">Password</label>
      <input type="password" id="inputPassword" name="inputPassword" class="form-control" placeholder="Password" required=""/>
      -->
  <!--<div class="checkbox">
          <label>
            <input type="checkbox" value="remember-me"/> Remember me
          </label>
        </div>-->
  <!--
      </br>
      <button class="btn btn-lg btn-primary btn-block" type="submit">Sign in</button>

    </form>
  </div>-->

  <form class="login default-margin" onsubmit="{onSubmit}">
    <div class="form-group">
      <label for="email">Email address</label>
      <input type="email" class="form-control" id="email" placeholder="Email" required/>
    </div>
    <div class="form-group">
      <label for="password">Password</label>
      <input type="password" class="form-control" id="password" placeholder="Password" required/>
    </div>

    <button type="submit" class="btn btn-lg btn-outline">Submit</button>
  </form>

  <script>

    this.onSubmit= function(){
    localStorage.setItem("IsEmployee", "");
    if(email.value=='john@pc.com' && password.value=='John@123')
    {
    localStorage.setItem("IsEmployee", "No");
    }

    riot.route('article/articleList');
    
    }
  </script>

</login>