using TabBlazor;

namespace MyIcons
{
    
    public static class Icons
    {
        public static IIconType Account => new MDIcon(@"<path d='M12,4A4,4 0 0,1 16,8A4,4 0 0,1 12,12A4,4 0 0,1 8,8A4,4 0 0,1 12,4M12,14C16.42,14 20,15.79 20,18V20H4V18C4,15.79 7.58,14 12,14Z' />");
        
        public static IIconType Shopping_bag => new TablerIcon(@"<path stroke='none' d='M0 0h24v24H0z' fill='none' /><path d='M6.331 8h11.339a2 2 0 0 1 1.977 2.304l-1.255 8.152a3 3 0 0 1 -2.966 2.544h-6.852a3 3 0 0 1 -2.965 -2.544l-1.255 -8.152a2 2 0 0 1 1.977 -2.304z' /><path d='M9 11v-5a3 3 0 0 1 6 0v5' />");

        public static IIconType Filled_zoom_money => new TablerIcon(@"<path stroke='none' d='M0 0h24v24H0z' fill='none' /><path d='M14 3.072a8 8 0 0 1 2.32 11.834l5.387 5.387a1 1 0 0 1 -1.414 1.414l-5.388 -5.387a8 8 0 0 1 -12.905 -6.32l.005 -.285a8 8 0 0 1 11.995 -6.643m-2 2.928h-2.5a2.5 2.5 0 0 0 0 5h1a.5 .5 0 1 1 0 1h-2.5a1 1 0 0 0 0 2h2.5a2.5 2.5 0 1 0 0 -5h-1a.5 .5 0 0 1 0 -1h2.5a1 1 0 0 0 0 -2' />");
        public static IIconType Filled_location => new TablerIcon(@"<path stroke='none' d='M0 0h24v24H0z' fill='none' /><path d='M20.891 2.006l.106 -.006l.13 .008l.09 .016l.123 .035l.107 .046l.1 .057l.09 .067l.082 .075l.052 .059l.082 .116l.052 .096c.047 .1 .077 .206 .09 .316l.005 .106c0 .075 -.008 .149 -.024 .22l-.035 .123l-6.532 18.077a1.55 1.55 0 0 1 -1.409 .903a1.547 1.547 0 0 1 -1.329 -.747l-.065 -.127l-3.352 -6.702l-6.67 -3.336a1.55 1.55 0 0 1 -.898 -1.259l-.006 -.149c0 -.56 .301 -1.072 .841 -1.37l.14 -.07l18.017 -6.506l.106 -.03l.108 -.018z' />");

    }
}
