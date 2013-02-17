
INSERT INTO
	_user (
		id,
		version,
		created_at,
		updated_on,
		isactive,
		islocked,

		usergroup_id,
		password,
		username
	)
	VALUES (
		@id,
		@version,
		@created_at,
		@updated_on,
		@isactive,
		@islocked,

		@usergroup_id,
		@password,
		@username
	);