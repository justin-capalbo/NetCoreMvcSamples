var gulp = require('gulp');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');

gulp.task("minify", function() {
    //Src allows us to specify the source of 'what files' do we want to do something with, and then return.

    //Pass in everything we find in source to the uglify function.
    //Then, concat the result with dutchtreat.min.js.
    //Finally, move this to wwwroot/dist.
    return gulp.src('wwwroot/js/**/*.js')
        .pipe(uglify())
        .pipe(concat('dutchtreat.min.js'))
        .pipe(gulp.dest('wwwroot/dist'));
});

//Loaded up by gulp runtime and executes what is in here as a build step.
//If we develop new tasks we can bundle them here.
gulp.task('default', ["minify"]);
