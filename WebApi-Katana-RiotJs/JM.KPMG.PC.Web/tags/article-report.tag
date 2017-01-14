<article-report class="default-margin">
  <button class="btn btn-default" id="sort" onclick="{sortBars}">Sort</button>
  <button class="btn btn-default" id="reset" onclick="{reset}">Reset</button>

  <div id="reportContainer" class=""></div>
  <div id="tooltip"></div>
  <script>

    this.on('mount', function () {

    var self = this;
    self.dataset=[];
    $.get('http://localhost:9000/api/Articles/GetAllArticleByLike', function(data, status){
    self.dataset=data;
    console.log( self.dataset);
    loadReport();
    self.update()
    });

    function loadReport(){

    var w = 600;
    var h = 250;

    var xScale = d3.scale.ordinal()
    .domain(d3.range(self.dataset.length))
    .rangeRoundBands([0, w], 0.05);

    var yScale = d3.scale.linear()
    .domain([0, d3.max(self.dataset, function (d) { return d.LikeCount; })])
   //.attr('x','Hello john')
   //.attr('y','Hello Jessy')
    .range([0, h]);

    var Id = function (d) {
    return d.Id;
    };

    //Create SVG element
    var svg = d3.select("#reportContainer")
    .append("svg")
    .attr("width", w)
    .attr("height", h);

    //Create bars
    svg.selectAll("rect")
    .data(self.dataset, Id)
    .enter()
    .append("rect")
    .attr("x", function (d, i) {
    return xScale(i);
    })
    .attr("y", function (d) {
    return h - yScale(d.LikeCount);
    })
    .attr("width", xScale.rangeBand())
    .attr("height", function (d) {
    return yScale(d.LikeCount);
    })
    .attr("fill", function (d) {
    return "rgb(0, 0, " + (d.LikeCount * 10) + ")";
    })

    //Tooltip
    .on("mouseover", function (d) {
    //Get this bar's x/y values, then augment for the tooltip

    var xPosition = parseFloat(d3.select(this).attr("x")) + xScale.rangeBand() / 2;
    var yPosition = parseFloat(d3.select(this).attr("y")) + 14;

    //Update Tooltip Position & value
    d3.select("#tooltip")
    .style("left", xPosition + "px")
    .style("top", yPosition + "px")
    .select("#LikeCount")
    .text(d.Title);
    d3.select("#tooltip").classed("hidden", false)
    })
    .on("mouseout", function () {
    //Remove the tooltip
    d3.select("#tooltip").classed("hidden", true);
    });

    //Create labels
    svg.selectAll("text")
    .data(self.dataset, Id)
    .enter()
    .append("text")
    .text(function (d) {
    return d.LikeCount;
    })
    .attr("text-anchor", "middle")
    .attr("x", function (d, i) {
    return xScale(i) + xScale.rangeBand() / 2;
    })
    .attr("y", function (d) {
    return h - yScale(d.LikeCount) + 14;
    })
    .attr("font-family", "sans-serif")
    .attr("font-size", "11px")
    .attr("fill", "white");

    var sortOrder = false;
    var sortBars = function () {
    sortOrder = !sortOrder;

    sortItems = function (a, b) {
    if (sortOrder) {
    return a.LikeCount - b.LikeCount;
    }
    return b.LikeCount - a.LikeCount;
    };

    svg.selectAll("rect")
    .sort(sortItems)
    .transition()
    .delay(function (d, i) {
    return i * 50;
    })
    .duration(1000)
    .attr("x", function (d, i) {
    return xScale(i);
    });

    svg.selectAll('text')
    .sort(sortItems)
    .transition()
    .delay(function (d, i) {
    return i * 50;
    })
    .duration(1000)
    .text(function (d) {
    return d.LikeCount;
    })
    .attr("text-anchor", "middle")
    .attr("x", function (d, i) {
    return xScale(i) + xScale.rangeBand() / 2;
    })
    .attr("y", function (d) {
    return h - yScale(d.LikeCount) + 14;
    });
    };
    // Add the onclick callback to the button
    d3.select("#sort").on("click", sortBars);
    d3.select("#reset").on("click", reset);

    function randomSort() {
    svg.selectAll("rect")
    .sort(sortItems)
    .transition()
    .delay(function (d, i) {
    return i * 50;
    })
    .duration(1000)
    .attr("x", function (d, i) {
    return xScale(i);
    });

    svg.selectAll('text')
    .sort(sortItems)
    .transition()
    .delay(function (d, i) {
    return i * 50;
    })
    .duration(1000)
    .text(function (d) {
    return d.LikeCount;
    })
    .attr("text-anchor", "middle")
    .attr("x", function (d, i) {
    return xScale(i) + xScale.rangeBand() / 2;
    })
    .attr("y", function (d) {
    return h - yScale(d.LikeCount) + 14;
    });
    }

    function reset() {
    svg.selectAll("rect")
    .sort(function (a, b) {
    return a.Id - b.Id;
    })
    .transition()
    .delay(function (d, i) {
    return i * 50;
    })
    .duration(1000)
    .attr("x", function (d, i) {
    return xScale(i);
    });

    svg.selectAll('text')
    .sort(function (a, b) {
    return a.Id - b.Id;
    })
    .transition()
    .delay(function (d, i) {
    return i * 50;
    })
    .duration(1000)
    .text(function (d) {
    return d.LikeCount;
    })
    .attr("text-anchor", "middle")
    .attr("x", function (d, i) {
    return xScale(i) + xScale.rangeBand() / 2;
    })
    .attr("y", function (d) {
    return h - yScale(d.LikeCount) + 14;
    });
    };
    }


    });

  </script>

</article-report>
