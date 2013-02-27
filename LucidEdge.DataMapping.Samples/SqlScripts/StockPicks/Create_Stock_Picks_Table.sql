CREATE TABLE stock_picks
(
  symbol character(10),
  username character(80),
  duration_days integer,
  start_date date,
  end_date date,
  insert_date date,
  correct_pick integer,
  id serial NOT NULL,
  CONSTRAINT stock_picks_pkey PRIMARY KEY (id)
);